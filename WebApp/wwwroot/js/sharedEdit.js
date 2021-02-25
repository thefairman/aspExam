$(document).ready(function () {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
});

//triggered when modal is about to be shown
$('#myDelModal').on('show.bs.modal', function (e) {

    //get data-id attribute of the clicked element
    let itemId = $(e.relatedTarget).data('item-id');
    let itemName = $(e.relatedTarget).data('item-name');

    var modal = $(this);
    modal.find("#deletedItemNameModal").text(itemName);
    modal.find("#deletedItemIdModal").text(itemId);
    //populate the textbox
    //$(e.currentTarget).find('input[name="bookId"]').val(bookId);
});


