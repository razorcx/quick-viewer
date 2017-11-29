using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Model;
using TSDUI = Tekla.Structures.Dialog.UIControls;

namespace QuickViewer
{
	public partial class QuickViewer : Form
	{
		private readonly Model _model = new Model();
		private List<Member> _data;
		private object _currentCellValue;

		public QuickViewer()
		{
			try
			{
				InitializeComponent();
				this.TopMost = true;
				this.cmbBoxMember.DataSource = GetBeamNames();
				this.txtBoxModelInfo.Text = _model.GetInfo().ModelName;
				UpdateStatus();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.InnerException + ex.Message + ex.StackTrace);
				throw;
			}
		}

		private void UpdateStatus()
		{
			var message = $"Diplaying: {this.cmbBoxMember.Text} ({_data.Count})";
			this.txtBoxStatus.Text = message;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			this.cmbBoxMember.DataSource = GetBeamNames();
			var beams = GetBeams();
			GetData(beams);
			this.txtBoxSearch.Text = string.Empty;
			this.dataGridMembers.DataSource = _data;
			UpdateStatus();
		}

		private void cmbBoxMember_SelectedIndexChanged(object sender, EventArgs e)
		{
			var beams = GetBeams();
			GetData(beams);
			this.txtBoxSearch.Text = string.Empty;
			this.dataGridMembers.DataSource = _data;
			UpdateStatus();
		}

		private List<string> GetBeamNames()
		{
			var beams =
				GetBeams()
				.Select(b => b.Name)
				.Distinct()
				.OrderBy(b => b)
				.ToList();

			beams.Insert(0, "ALL");
			return beams;
		}

		private void GetData(List<Beam> beams)
		{
			if (!(this.cmbBoxMember.Text == "ALL"))
				beams = beams.Where(b => b.Name == this.cmbBoxMember.Text).ToList();

			_data = beams
				.Select(b =>
				{
					var phase = -1;
					b.GetReportProperty("PHASE", ref phase);

					var assemblyPos = string.Empty;
					b.GetReportProperty("ASSEMBLY_POS", ref assemblyPos);

					return new Member
					{
						Id = b.Identifier.ID,
						Phase = phase,
						AssemblyMark = assemblyPos,
						Name = b.Name,
						Profile = b.Profile.ProfileString,
						Class = b.Class,
						Finish = b.Finish,
						Material = b.Material.MaterialString,
					};
				})
				.OrderBy(b => b.Phase)
				.ThenBy(b => b.Name)
				.ThenBy(b => b.Profile)
				.ToList();
		}

		private List<Beam> GetBeams()
		{
			ModelObjectEnumerator.AutoFetch = true;
			var moe = _model.GetModelObjectSelector().GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM);
			return 
				moe
				.ToList()
				.OfType<Beam>()
				.ToList();
		}

		private void SelectModelObjectsInUi(List<int> ids)
		{
			var modelObjects = new ArrayList();

			ids.ForEach(id => 
			{
				var modelObject = _model.SelectModelObject(new Identifier(id));
				if (modelObject == null) return;
				modelObjects.Add(modelObject);
			});

			var selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
			selector.Select(modelObjects);
		}

		private void txtBoxSearch_TextChanged(object sender, EventArgs e)
		{
			var searchText = ((TextBox) sender).Text;
			if (string.IsNullOrEmpty(searchText)) return;

			var beams = GetBeams();
			if (!(this.cmbBoxMember.Text == "ALL"))
				beams = beams.Where(b => b.Name == this.cmbBoxMember.Text).ToList();

			beams = beams
				.Where(b =>
				{
					var assemblyPos = string.Empty;
					b.GetReportProperty("ASSEMBLY_POS", ref assemblyPos);

					return assemblyPos.Contains(searchText);
				})
				.ToList();

			GetData(beams);
			this.dataGridMembers.DataSource = _data;
			UpdateStatus();
		}

		private void dataGridMembers_SelectionChanged(object sender, EventArgs e)
		{
			var selectedRows = GetSelectedRows(sender);
			var ids = GetIds(selectedRows);
			SelectModelObjectsInUi(ids);
		}

		private List<DataGridViewRow> GetSelectedRows(object sender)
		{
			var dataGrid = sender as TSDUI.DataGrid;
			return dataGrid?.SelectedRows.OfType<DataGridViewRow>().ToList();
		}

		private List<int> GetIds(List<DataGridViewRow> rows)
		{
			return rows
				.Select(r => (int)((dynamic)r.DataBoundItem).Id)
				.ToList();
		}

		private void logo_Click(object sender, EventArgs e)
		{
			Process.Start("http://razorcx.com");
		}

		private void dataGridMembers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			if (dataGridView == null) return;

			try
			{
				var row = dataGridView?.CurrentRow;
				if (row == null) return;

				var cell = dataGridView.CurrentCell.Value;
				var cellValue = cell?.ToString() ?? string.Empty;
				var columnName = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name.ToUpper();
				var id = (int) ((dynamic) row.DataBoundItem).Id;

				var part = _model.SelectModelObject(new Identifier(id)) as Part;
				if (part == null) return;

				var commitChanges = false;

				switch (columnName)
				{
					case "NAME":
						part.Name = cellValue;
						break;
					case "PROFILE":
						if (!string.IsNullOrEmpty(cellValue))
						{
							part.Profile = new Profile() {ProfileString = cellValue};
							commitChanges = true;
						}
						break;
					case "CLASS":
						if (int.Parse(cellValue) > 0 && int.Parse(cellValue) < 100)
						{
							part.Class = cellValue;
							commitChanges = true;
						}
						break;
					case "FINISH":
						part.Finish = cellValue;
						break;
					case "MATERIAL":
						if (!string.IsNullOrEmpty(cellValue))
						{
							part.Material = new Material() {MaterialString = cellValue};
							commitChanges = true;
						}
						break;
				}

				if (columnName == "MATERIAL" && string.IsNullOrEmpty(cellValue))
				{
					dataGridView.CurrentCell.Value = _currentCellValue;
					return;
				}

				if (columnName == "PROFILE" && string.IsNullOrEmpty(cellValue))
				{
					dataGridView.CurrentCell.Value = _currentCellValue;
					return;
				}

				if (columnName == "CLASS" && !(int.Parse(cellValue) > 0 && int.Parse(cellValue) < 100))
				{
					dataGridView.CurrentCell.Value = _currentCellValue;
					return;
				}

				var success = part.Modify();
				if (!success)
				{
					dataGridView.CurrentCell.Value = _currentCellValue;
					return;
				}

				if (commitChanges)
					_model.CommitChanges();

				_currentCellValue = null;
			}
			catch (Exception ex)
			{
				dataGridView.CurrentCell.Value = _currentCellValue;
			}
		}

		private void dataGridMembers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			var dataGridView = sender as DataGridView;
			_currentCellValue = dataGridView?.CurrentCell.Value;
		}
	}
}
