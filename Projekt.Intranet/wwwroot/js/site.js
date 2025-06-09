var $j = jQuery.noConflict();

$j(document).ready(function () {
    var table = $j('#datatable').DataTable({
        paging: true,
        ordering: true,
        searching: true,
        info: true,
        responsive: true,
        lengthMenu: [10, 25, 50],
        scrollX: true,
        scrollY: true,
        language: {
            paginate: {
                previous: "Poprzednia",
                next: "Następna"
            }
        },
        initComplete: function () {
            var api = this.api();
            api.columns().every(function (index) {
                var column = this;
                $j('input', api.table().header().querySelectorAll('tr')[1].cells[index]).on('keyup change clear', function () {
                    if (column.search() !== this.value) {
                        column.search(this.value).draw();
                    }
                });
            });
        }
    });

    $j('#datatable tbody tr').css({
        'padding-top': '1.5rem',
        'padding-bottom': '1.5rem',
        'height': '3rem'
    });
});
