var selectAll = "http://localhost:44542/Pessoas/"


//$( "#delete-a536451d-1c2a-4853-894b-2259f5df321d" ).on("click",function() {
//	console.log('teste');
//});


function update_pessoa(id) {

	var name = $('input#input_nome');
	var dt_nasc = $('input#input_dtn');
	var cpf = $('input#input_cpf');
	var data;
	data =  {'id': id,'nome': name.val(),'dt_Nascimento': dt_nasc.val(),'cpf': cpf.val(),}
	data = JSON.stringify(data)
	$.ajax({
		url: selectAll,
		type: 'PUT',
		contentType: 'application/json; charset=utf-8',
		data: data,
		success: function (a) {
			get_pessoas();
		},
		error: function () {
			console.log('deu erro')
			get_pessoas();
		},
	});

	get_pessoas();
}

function insert_pessoa() {

	var name = $('input#input_nome_new');
	var dt_nasc = $('input#input_dtn_new');
	var cpf = $('input#input_cpf_new');
	var data;
	data = { 'nome': name.val(), 'dt_Nascimento': dt_nasc.val(), 'cpf': cpf.val(), };
	data = JSON.stringify(data);
	$.ajax({
		url: selectAll,
		type: 'POST',
		contentType: 'application/json; charset=utf-8',
		data: data,
		success: function (a) {
			get_pessoas();
		},
		error: function () {
			console.log('deu erro')
			get_pessoas();
		},
	});

	get_pessoas();
}


function cadastrar_pessoa(link) {
	let nome = document.getElementById('input_nome')
	console.log(nome)
}

cadastrar_pessoa(selectAll);

function closeModalUpdate() {
	var element = document.getElementById('modal_update');
	element.classList.remove('active');
}

function closeModalInsert() {
	var element = document.getElementById('modal');
	element.classList.remove('active');
}

function openModalUpdate() {
	var element = document.getElementById('modal_update');
	element.classList.add('active');
}

function openModalInsert() {
	var element = document.getElementById('modal');
	element.classList.add('active');
}


function get_pessoa(id) {
	openModalUpdate();
	var name = $('input#input_nome');
	var dt_nasc = $('input#input_dtn');
	var cpf = $('input#input_cpf');
	var botao = $('#salvar');
	botao.attr('onclick', 'update_pessoa(\'' + id + '\')');

	$.getJSON((selectAll + id), function (data) {

		name.val(data.nome);
		dt_nasc.val(data.dt_Nascimento);
		cpf.val(data.cpf);

	});

}

function post_pessoa(id) {
	openModalInsert();
	var name = $('input#input_nome_new');
	var dt_nasc = $('input#input_dtn_new');
	var cpf = $('input#input_cpf_new');
	var botao = $('#incluir');
	botao.attr('onclick', 'insert_pessoa()');

	$.getJSON((selectAll), function (data) {

		name.val(data.nome);
		dt_nasc.val(data.dt_Nascimento);
		cpf.val(data.cpf);
	});
}


function delete_pessoa(id) {

	$.ajax({
		url: selectAll + id,
		type: 'DELETE',
		success: function (a) {
			get_pessoas();
		},
		error: function() {
			console.log('deu erro')
			get_pessoas();
		},
	});

	get_pessoas();
}

function get_pessoas() {
	$.getJSON(selectAll, function(data) {

		var elemento = '';

		$.each(data, function (chave, valor) {
			//console.log(valor.nome);
			elemento += '<tr>';
			elemento += '<td>' + valor.nome + '</td>';
			elemento += '<td>' + valor.dt_Nascimento + '</td>';
			elemento += '<td>' + valor.cpf + '</td>';
			elemento += '</td>';
			elemento += '<td> <button type="button" class="button green mobile cadastrarCliente" id="cadastrarCliente" onclick="get_pessoa(\'' + valor.id + '\')">Editar</button>';
			elemento += '<button type="button" id="delete-' + (valor.id) + '" onclick="delete_pessoa(\'' + valor.id + '\')" class="button red">excluir</button></td>';
		});

		$('tbody#listagem').html(elemento);

		console.log(elemento);
	});
}







