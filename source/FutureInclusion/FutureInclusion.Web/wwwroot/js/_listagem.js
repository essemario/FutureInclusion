$(document).ready(function () {
    $('.tabela-linha-clicavel').on('click', 'td:not(.td-acaoes)', function () {
        window.location = $('.tabela-linha-clicavel').data("href");
    });

    $('#confirm-delete').on('show.bs.modal', function (e) {
        $(this).find('.btn-ok').attr('href', $(e.relatedTarget).data('href'));
    });
});