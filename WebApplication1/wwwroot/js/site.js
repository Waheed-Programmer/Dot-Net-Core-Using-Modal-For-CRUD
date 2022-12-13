// Write your JavaScript code.

$(document).ready(function () {
    ShowEmployeList();
    //alert("Welcome")
    //$('#myTable').DataTable({
    //    "aLengthMenu": [[5, 10, 50, 100, -1], [5, 10, 50, 100, "All"]],
    //});
});
//Load Data into tables
function ShowEmployeList() {
    $.ajax({
        url: '/Ajax/EmployeList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result,status,xhr)
        {
            var obj = '';
            $.each(result, function (index, item) {
                obj += '<tr>';
                obj += '<td>' + item.employeeId + '</td>';
                obj += '<td>' + item.employeeName + '</td>';
                obj += '<td>' + item.employeeEmail + '</td>';
                obj += '<td>' + item.employeeContact + '</td>';
                obj += '<td>' + item.employeeAddress + '</td>';
                obj += '<td><a href = "#" class="btn btn-primary btn-sm" onclick="Edit('+item.employeeId+')" >Edit</a > || <a href = "#" class="btn btn-danger btn-sm" onclick="Delete('+item.employeeId+')" >Delete</a ></td>';
                obj += '</tr>';

            });
            $('#table_data').html(obj);
        },
        error: function () {}
    })
};
//Modal open 
$('#btnAddEmployee').click(function () {
    Clear();
    $('#Employeemodal').modal('show');
    $('#HeadId').text('Add Record');
    $('#btnUpdateEmployee').css('display', 'none');
    $('#InsertEmployee').css('display', 'block');
    
});
//Modal Hide
function HidePopUpModal()
{
    $('#Employeemodal').modal('hide');
}
//Clear value from textbox
function Clear() {
    $('#EmployeeName').val('')
    $('#EmployeeEmail').val('');
    $('#EmployeeContact').val('');
    $('#EmployeeAddress').val('');
}
//Add Employee Data
function addEmployee() {
    debugger
    var objData = {
        EmployeeName: $('#EmployeeName').val(),
        EmployeeEmail: $('#EmployeeEmail').val(),
        EmployeeContact: $('#EmployeeContact').val(),
        EmployeeAddress: $('#EmployeeAddress').val()
    }
    $.ajax({
        type: 'Post',
        url: '/Ajax/addEmployee',
        data: objData,
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        success: function (result) {
            alert("Data Save")
            Clear();
            ShowEmployeList();
            HidePopUpModal();
        },
        error: function () { }
    });
}
//Delete Employee Data
function Delete(id)
{
    if (confirm('Are you sure to want to delete this record?')) {
        $.ajax({
            url: '/Ajax/Delete?id=' + id,
            success: function () {

                alert('Record is Deleted');
                ShowEmployeList();
            },
            error: function (error) {
                alert('Record is not Deleted');
            }
        })
    }
    
}
//Get Data by Id
function Edit(id) {
    
    
    $.ajax({
        type: 'Get',
        url: '/Ajax/GetbyId?id=' +id,       
        dataType: 'json',
        success: function (result) {
            debugger
            $('#Employeemodal').modal('show');
            $('#EmployeeId').val(result.employeeId);
            $('#EmployeeName').val(result.employeeName);
            $('#EmployeeEmail').val(result.employeeEmail);
            $('#EmployeeContact').val(result.employeeContact);
            $('#EmployeeAddress').val(result.employeeAddress);
            $('#InsertEmployee').css('display','none');
            $('#btnUpdateEmployee').css('display', 'block');
            $('#HeadId').text('Update Record');


            //$('#btnUpdateEmployee').show();

            
        },
        error: function () { }
    });
}
//Update data function
function UpdateEmployee() {
    debugger
    var objData = {
        EmployeeId: $('#EmployeeId').val(),
        EmployeeName: $('#EmployeeName').val(),
        EmployeeEmail: $('#EmployeeEmail').val(),
        EmployeeContact: $('#EmployeeContact').val(),
        EmployeeAddress: $('#EmployeeAddress').val()
    }
    $.ajax({
        type: 'Post',
        url: '/Ajax/Update',
        data: objData,
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        success: function (result) {
            alert("Data Updated")
            Clear();
            ShowEmployeList();
            HidePopUpModal();
        },
        error: function () { }
    });
}