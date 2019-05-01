$('#tabela-datatable').DataTable({
	"language": {
		"sEmptyTable": "Nenhum registro encontrado",
		"sInfo": "Mostrando de _START_ até _END_ de um total de _TOTAL_ registros",
		"sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
		"sInfoFiltered": "",
		"sInfoPostFix": "",
		"sInfoThousands": ".",
		"sLengthMenu": "_MENU_ resultados por página",
		"sLoadingRecords": "Carregando...",
		"sProcessing": "Processando...",
		"sZeroRecords": "Nenhum registro encontrado",
		"sSearch": "Pesquisar",
		"oPaginate": {
			"sNext": "Próximo",
			"sPrevious": "Anterior",
			"sFirst": "Primeiro",
			"sLast": "Último"
		},
		"oAria": {
			"sSortAscending": ": Ordenar de forma crescente",
			"sSortDescending": ": Ordenar de forma decrescente"
		}
	},
	processing: true,
	serverSide: true,
	"columnDefs": [
		{ "name": "Nome", "targets": 0 },
		{ "name": "CPF", "targets": 1 },
		{ "name": "Telefone", "targets": 2 },
		{ "name": "Id", "targets": 3 }
	],
	ajax: {
		url: '/Home/Filtro',
		type: 'POST'
	},
	columns: [

		{ data: 'Nome', name: 'Nome' },
		{ data: 'CPF', name: 'CPF' },
		{ data: 'Telefone', name: 'Telefone' },
		{
			data: 'Id',
			name: 'Id', 
			render: function (data) {
				return "<a class='btn btn-default' href='/Home/Edit/" + data + "'>Editar</a>" + 
					   "<a class='btn btn-danger' href='/Home/Delete/" + data + "'>Excluir</a>";
			}
		}
	],
	autofill: true,
	select: true,
	responsive: true,
	buttons: true
});