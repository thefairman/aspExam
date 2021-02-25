// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let faculties = {};
function fillFaculties(selected, selectGroupName) {
    //console.log(selected);
    if (Array.isArray(faculties) && faculties.length > 0)
        fillSelect(faculties, selected, selectGroupName);
    else {
        $.ajax({
            url: "api/Faculty/WithGroups",
            dataType: "json",
            success: function (e) {
                faculties = e['rows'];
                fillSelect(faculties, selected, selectGroupName);
            },
            error: function () {
                toastr["error"]("Can't load faculties!");
            }
        });
    }
}

function fillSelect(arr, selected, selectGroupName) {
    if (!Array.isArray(faculties) || faculties.length <= 0)
        return;
    if ($("#selectFacultyInForm option").length <= 1) {
        $.each(arr, function (index, value) {
            let option = $("<option></option>")
                .attr("value", value['id'])
                .text(value['name']);
            $('#selectFacultyInForm')
                .append(option);
            if (value['name'] === selected) {
                option.prop('selected', true);
                fillGroupSelect($('#selectFacultyInForm'));
            }
        });
    } else {
        $(("#selectFacultyInForm option")).each(function () {
            let txt = $(this).text();
            if (txt === selected) {
                $(this).prop('selected', true);
                fillGroupSelect($(this).parent())
                return false;
            }
        });
    }
    if (selected === undefined)
        $("#selectFacultyInForm option")[0].selected = true;
    selectGroupByName(selectGroupName);
        //$("#selectFacultyInForm").val([]);
}

$('#selectFacultyInForm').on('change', function () {
    fillGroupSelect($(this));
});

function fillGroupSelect(facultySelect) {
    let selectedOpt = facultySelect.find(":selected");
    if (selectedOpt.val() === undefined)
        return;
    $("#selectGroupInForm").empty();
    $("#selectGroupInForm").prepend($('<option>-- Select group --</option>'));
    let obj = faculties.find(x => x.name === selectedOpt.text());
    obj.groups.forEach(function (currentValue) {
        $("#selectGroupInForm").append($('<option value=' + currentValue.id + '>' + currentValue.name + '</option>'));
    });
}

function selectGroupByName(name) {
    if (name === undefined) {
        $("#selectGroupInForm").empty();
        $("#selectGroupInForm").prepend($('<option>-- Select group --</option>'));
        return;
    }
    $("#selectGroupInForm option").each(function () {
        let tmp = $(this).text();
        if (tmp === name) {
            $(this).prop('selected', true);
            return false;
        }
    });
}

$('#myEditModal').on('show.bs.modal', function (e) {

    //get data-id attribute of the clicked element
    let itemId = $(e.relatedTarget).data('item-id');
    let itemName = $(e.relatedTarget).data('item-name');
    let itemLastName = $(e.relatedTarget).data('item-lastname');
    let itemFaculy = $(e.relatedTarget).data('item-faculty');
    let itemGroup = $(e.relatedTarget).data('item-group');

    fillFaculties(itemFaculy, itemGroup);
    //selectGroupByName(itemGroup);
    var modal = $(this);
    modal.find("input[name='firstName']").val(itemName);
    modal.find("input[name='lastName']").val(itemLastName);
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
        modal.find('.modal-title').text("Редактрирование элемента");
    }
    //populate the textbox
    //$(e.currentTarget).find('input[name="bookId"]').val(bookId);
});

//$('#myEditModal').on('hide.bs.modal', function (e) {
//    $('#selectFacultyInForm option:selected').removeAttr('selected');
//});

function checkFields() {
    let gn = $("#recipient-name").val();
    let ln = $("#recipient-lastName").val();
    //console.log(gn);
    if (gn.length == 0) {
        toastr["error"]("First name is empty");
        return false;
    }
    if (ln.length == 0) {
        toastr["error"]("Last name is empty");
        return false;
    }
    if ($('#selectFacultyInForm option:selected') === undefined || $('#selectFacultyInForm option:selected').index() <=0 ) {
        toastr["error"]("Select a faculty");
        return false;
    }
    if ($('#selectGroupInForm option:selected') === undefined || $('#selectGroupInForm option:selected').index() <= 0 ) {
        toastr["error"]("Select a group");
        return false;
    }
    return true;
}

function addItem() {
    if (checkFields()) {
        $.ajax({
            url: "api/Student",
            contentType: 'application/json',
            method: "put",
            data: JSON.stringify({
                FirstName: $("#recipient-name").val(),
                LastName: $("#recipient-lastName").val(),
                FacultyId: $('#selectFacultyInForm').val(),
                GroupId: $('#selectGroupInForm').val()
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
            url: "api/Student",
            contentType: 'application/json',
            method: "put",
            data: JSON.stringify({
                Id: $("#studentId").val(),
                FirstName: $("#recipient-name").val(),
                LastName: $("#recipient-lastName").val(),
                FacultyId: $('#selectFacultyInForm').val(),
                GroupId: $('#selectGroupInForm').val()
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
        url: "api/Student/" + $("span#deletedItemIdModal").text(),

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
        class="btn btn-primary" data-item-id="' + row.id + '" data-item-name="' + row.firstName + '" data-item-lastname="' + row.lastName +'" data-item-faculty="' + row.group.faculty.name + '" data-item-group="' + row.group.name + '">EDIT</button>';
}

function facultyFormatter(value, row) {
    return row.group.faculty.name;
}

function groupFormatter(valur, row) {
    return row.group.name;
}