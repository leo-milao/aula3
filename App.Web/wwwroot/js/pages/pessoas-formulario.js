$(document).ready(function () {
    loadCidades();
});

function Salvar() {
    let obj = {
        peso: (parseInt$("[name='peso']").val() || 0),
        nome: ($("[name='name']").val() || ''),
        dataNascimento: ($("[name='dataNascimento']").val() || ''),
        cidade: ($("[name='cidade']").val() || ''),
    };
    PessoaSalvar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}

function loadCidades() {
    CidadeListaCidades('').then(function (data) {
        data.forEach(obj => {
            $('#cidadeId').append('<option value="' + obj.id + '">' + obj.nome + '</option>');
        });
        $('#cidadeId').select2();
    });
}