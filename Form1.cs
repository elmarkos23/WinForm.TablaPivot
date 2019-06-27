using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WinForm.TablaPivot
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
				List<Documentos> lst = new List<Documentos>();
			lst.Add(new Documentos { MES = "ENERO", TOTAL = 6000, TIPO = "FAC" });
			lst.Add(new Documentos { MES = "ENERO", TOTAL = 200, TIPO = "FAC" });
			lst.Add(new Documentos { MES = "FEBRERO", TOTAL = 6500, TIPO = "RET" });
			lst.Add(new Documentos { MES = "ENERO", TOTAL = 400, TIPO = "RET" });
			lst.Add(new Documentos { MES = "DICIEMBRE", TOTAL = 560, TIPO = "FAC" });
			lst.Add(new Documentos { MES = "AGOSTO", TOTAL = 1400, TIPO = "RET" });
						
		var query = lst
		.GroupBy(c => c.TIPO)
		.Select(g => new
		{
			TIPO = g.Key,
			ENERO = g.Where(x => x.MES == "ENERO").Sum(x => x.TOTAL),
			FEBRERO = g.Where(x => x.MES == "FEBRERO").Sum(x => x.TOTAL),
			MARZO = g.Where(x => x.MES == "MARZO").Sum(x => x.TOTAL),
			ABRIL = g.Where(x => x.MES == "ABRIL").Sum(x => x.TOTAL),
			MAYO = g.Where(x => x.MES == "MAYO").Sum(x => x.TOTAL),
			//JUNIO = g.Where(x => x.MES == "JUNIO").Sum(x => x.TOTAL),
			//JULIO = g.Where(x => x.MES == "JULIO").Sum(x => x.TOTAL),
			//AGOSTO = g.Where(x => x.MES == "AGOSTO").Sum(x => x.TOTAL),
			//SEPTIEMBRE = g.Where(x => x.MES == "SEPTIEMBRE").Sum(x => x.TOTAL),
			//OCTUBRE = g.Where(x => x.MES == "OCTUBRE").Sum(x => x.TOTAL),
			//NOVIEMBRE = g.Where(x => x.MES == "NOVIEMBRE").Sum(x => x.TOTAL),
			//DICIEMBRE = g.Where(x => x.MES == "DICIEMBRE").Sum(x => x.TOTAL),
			TOTAL = g.Sum(c => c.TOTAL)
		});
			
			var totales = new { TIPO = "TOTAL",
				ENERO = query.Sum(x => x.ENERO),
				FEBRERO = query.Sum(x => x.FEBRERO),
				MARZO = query.Sum(x => x.MARZO),
				ABRIL = query.Sum(x => x.ABRIL),
				MAYO = query.Sum(x => x.MAYO),
				TOTAL = query.Sum(x => x.TOTAL)
			};

			var midata = query.ToList();

			midata.Add(totales);

			dataGridView1.DataSource = midata.ToList();
		}
	
	}
}
