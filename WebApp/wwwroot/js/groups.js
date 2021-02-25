// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let faculties = [];
function fillFaculties(selected) {
    //console.log(selected);
    if (Array.isArray(faculties) && faculties.length > 0)
        fillSelect(faculties, selected);
    else {
        $.ajax({
            url: "api/Faculty",
            dataType: "json",
            success: function (e) {
                faculties = e['rows'];
                fillSelect(faculties, selected);
            },
            error: function () {
                toastr["error"]("Can't load faculties!");
            }
        });
    }
}

function fillSelect(arr, selected) {
    if (!Array.isArray(faculties) || faculties.length <= 0)
        return;
    if ($("#selectFacultyInForm option").length <= 1) {
        $.each(arr, function (index, value) {
            let option = $("<option></option>")
                .attr("value", value['id'])
                .text(value['name']);
            if (value['name'] === selected)
                option.prop('selected', true);
            $('#selectFacultyInForm')
                .append(option);
        });
    } else {
        $(("#selectFacultyInForm option")).each(function () {
            if ($(this).text() === selected) {
                $(this).prop('selected', true);
                return false;
            }
        });
    }
    if (selected === undefined)
        $("#selectFacultyInForm option")[0].selected = true;
        //$("#selectFacultyInForm").val([]);
}

$('#myEditModal').on('show.bs.modal', function (e) {

    //get data-id attribute of the clicked element
    let itemId = $(e.relatedTarget).data('item-id');
    let itemName = $(e.relatedTarget).data('item-name');
    let itemFaculy = $(e.relatedTarget).data('item-faculty');

    fillFaculties(itemFaculy);
    var modal = $(this);
    modal.find("input[name='name']").val(itemName);
    modal.find("input[name='id']").val(itemId);
    let confirmBtn = modal.find("#editBtn");
    //console.log(confirmBtn);
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

//$('#myEditModal').on('hide.bs.modal', function (e) {
//    $('#selectFacultyInForm option:selected').removeAttr('selected');
//});

function checkFields() {
    let gn = $("#recipient-name").val();
    //console.log(gn);
    if (gn.length == 0) {
        toastr["error"]("Group name is empty");
        return false;
    }
    if ($('#selectFacultyInForm option:selected') === undefined || $('#selectFacultyInForm option:selected').index() <= 0 ) {
        toastr["error"]("Select a faculty");
        return false;
    }
    return true;
}

function addItem() {
    if (checkFields()) {
        $.ajax({
            url: "api/Group",
            contentType: 'application/json',
            method: "put",
            data: JSON.stringify({
                Name: $("#recipient-name").val(),
                FacultyId: $('#selectFacultyInForm').val()
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
}

function editItem() {
    //debugger
    if (checkFields()) {
        $.ajax({
            url: "api/Group",
            contentType: 'application/json',
            method: "put",
            data: JSON.stringify({
                Id: $("#groupId").val(),
                Name: $("#recipient-name").val(),
                FacultyId: $('#selectFacultyInForm').val()
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
}

function deleteItem (){
    $.ajax({
        url: "api/Group/" + $("span#deletedItemIdModal").text(),

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

function formatDetail(value, row) {
    return '<button type="button" data-toggle="modal" data-target=".bd-example-modal-sm"\
        class="btn btn-danger" data-item-id="' + row.id + '" data-item-name="' + row.name + '"">DEL</button>\
        <button type="button" data-toggle="modal" data-target="#myEditModal"\
        class="btn btn-primary" data-item-id="' + row.id + '" data-item-name="' + row.name + '"data-item-faculty="' + row.faculty.name + '"">EDIT</button>';
}

function facultyFormatter(value, row) {
    return row.faculty.name;
}