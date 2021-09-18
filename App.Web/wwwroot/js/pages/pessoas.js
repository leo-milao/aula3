$(document).ready(function () {
    load();
});


function load() {
    load 
    PessoaListaPessoas().then(function (data) {
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.peso || '--') + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') +'</td>' +
                '<td>' + (obj.cidade.nome || '--') + '</td>' +
                '</tr>');
        });
    });
}