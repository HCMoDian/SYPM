$(function(){ 
				$('#ptasktable').datagrid({
												onClickRow: function(rowIndex,rowData)
													{
													alert("����");
													},
												onDblClickRow: function(rowIndex,rowData)
													{
													alert("˫��");
													}
												});
			});