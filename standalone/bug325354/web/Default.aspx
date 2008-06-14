<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
	<script runat="server">
		ICollection CreateDataSource() 
		{
			DataTable dt = new DataTable();
			DataRow dr;

			dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
			dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
			dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));

			for (int i = 0; i < 9; i++) {
				dr = dt.NewRow();
				dr[0] = i;
				dr[1] = "Item " + i.ToString();
				dr[2] = 1.23 * (i + 1);
				dt.Rows.Add(dr);
			}

			DataView dv = new DataView(dt);
			return dv;
		}

		void Page_Load(Object sender, EventArgs e) 
		{
			if (!IsPostBack) {
				ItemsGrid.DataSource= CreateDataSource();
				ItemsGrid.DataBind();
			}
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:datagrid id=ItemsGrid runat=server headerstyle-font-names=tahoma AutoGenerateColumns=true />
	</form>
</body>
</html>
