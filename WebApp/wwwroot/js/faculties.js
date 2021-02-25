// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkFields() {
    let fn = $("#recipient-name").val();
    if (fn.length == 0) {
        toastr["error"]("faculty name is empty");
        return false;
    }
    return true;
}

function addItem() {
    if (!checkFields())
        return;
    $.ajax({
        url: "api/Faculty",
        //dataType: 'json',
        contentType: 'application/json',
        method: "post",//put
        data: ['{ "Name": "', $("#recipient-name").val(), '" }'].join(""),
        success: function (data) {
            $('#myEditModal').modal('hide');
            $("#tt").datagrid('reload')
            toastr["success"]("GOOD! " + data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //debugger;
            $("#tt").datagrid('reload')
            toastr["error"]("VERY BAD! " + data);
        }
    })
}

function deleteItem() {
    $.ajax({
        url: "api/Faculty/" + $("span#deletedItemIdModal").text(),

        method: "delete",
        processData: false,
        contentType: false,
        data: "",
        success: function () {
            $('#myDelModal').modal('hide');
            $("#tt").datagrid('reload')
            toastr["success"]("GOOD!");
        },
        error: function () {
            $("#tt").datagrid('reload')
            toastr["error"]("VERY BAD!");
        }
    })
}

function editItem() {
    //console.log($("#facultyId").val());
    //console.log($("#recipient-name").val());
    if (!checkFields())
        return;
    $.ajax({
        url: "api/Faculty",
        contentType: 'application/json',
        method: "put",
        data: JSON.stringify({
            Id: $("#facultyId").val(),
            Name: $("#recipient-name").val()
        }),
        success: function () {
            $('#myEditModal').modal('hide');
            $("#tt").datagrid('reload');
            toastr["success"]("GOOD!");
        },
        error: function (e) {
            //console.log(e);
            $("#tt").datagrid('reload');
            toastr["error"]("VERY BAD!");
        }
    })
}

//triggered when modal is about to be shown
$('#myEditModal').on('show.bs.modal', function (e) {

    //get data-id attribute of the clicked element
    let itemId = $(e.relatedTarget).data('item-id');
    let itemName = $(e.relatedTarget).data('item-name');

    var modal = $(this);
    modal.find("input[name='name']").val(itemName);
    modal.find("input[name='id']").val(itemId);
    let confirmBtn = modal.find("#editBtn");
    if (itemId === undefined) {
        confirmBtn.off('click').on('click', addItem);
        confirmBtn.text("Add");
        modal.find('.modal-title').text("Добавление элемента");
    }
    else {
        confirmBtn.off('click').on('click', editItem);
        confirmBtn.text("Edit");
        modal.find('.modal-title').text("Редактирование элемента");
    }
    //populate the textbox
    //$(e.currentTarget).find('input[name="bookId"]').val(bookId);
});


function formatDetail(value, row) {
    return '<button type="button" data-toggle="modal" data-target=".bd-example-modal-sm"\
        class="btn btn-danger" data-item-id="' + row.id + '" data-item-name="' + row.name + '"">DEL</button>\
        <button type="button" data-toggle="modal" data-target="#myEditModal"\
        class="btn btn-primary" data-item-id="' + row.id + '" data-item-name="' + row.name + '"">EDIT</button>';
}