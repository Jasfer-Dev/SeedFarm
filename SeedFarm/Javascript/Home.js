function loadpage(obj) {
    var sectionUrl = $(obj).data("sectionurl");
    $.ajax({
        url: sectionUrl,
        type: "GET",
        success: function (result) {
            $('#divBilling').html(result);
        },
        error: function (xhr) {
            alert('error');
        }
    });
    return false;
}


function SaveBill() {

    var tr = $("#tblBillingDesc tbody tr");
    var mainObj = new Object();
    mainObj.CustomerName = $('#CustomerName').val();
    mainObj.FatherName = $('#FatherName').val();
    mainObj.Address = $('#Address').val();
    mainObj.City = $('#City').val();
    mainObj.State = $('#State').val();


    var obj_arr = new Array();
    for (var i = 1; i < tr.length; i++) {
        var obj = new Object();
        var tdnodes = $(tr[i]).find('td');
        obj.Description = $(tdnodes[1])[0].innerText;
        obj.Packing = $(tdnodes[2])[0].innerText;
        obj.RatePerPacking = $(tdnodes[3])[0].innerText;
        obj.NoOfPacking = $(tdnodes[4])[0].innerText;
        obj.Amount = $(tdnodes[5])[0].innerText;
        obj_arr.push(obj);
    }
    mainObj.BillDescList = obj_arr;

    var form = $("#frmBilling");
    $.ajax({
        url: "SaveBill/Home",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(mainObj),
        success: function (result) {
            if (result.success) {
                $("#divBilling").html(result);
            }
        },
        error: function (xhr) {
            $("#divBilling").html('');
            $("#divBilling").html(xhr.responseText);
        }
    });

}




function addRow() {

    var Description = document.getElementById("Description");
    var Packing = document.getElementById("Packing");
    var RPPacking = document.getElementById("RatePerPacking");
    var NoOfPacking = document.getElementById("NoOfPacking");
    var Amount = document.getElementById("Amount");
    var table = document.getElementById("tblBillingDesc");

    var rowCount = 0;
    var SNo = 0;
    var hdnRowCount = parseInt($("#hdnRowIndex").val());
    if (hdnRowCount >0) {
        rowCount = hdnRowCount;
        $("#hdnRowIndex").val('');
    } else {
        rowCount = table.rows.length;
    }

    var row = table.insertRow(rowCount);

    if (hdnRowCount > 0) {
        SNo = hdnRowCount;
    } else {
        SNo = table.rows.length - 1;
    }

    row.insertCell(0).innerHTML = SNo;
    row.insertCell(1).innerHTML = Description.value;
    row.insertCell(2).innerHTML = Packing.value;
    row.insertCell(3).innerHTML = RPPacking.value;
    row.insertCell(4).innerHTML = NoOfPacking.value;
    row.insertCell(5).innerHTML = Amount.value;
    row.insertCell(6).innerHTML = '<input style="height: 35px;width: 80px;line-height: 0;padding: 0;" type="button" value = "Edit" onClick="Javacsript:EditRow(this)">';
    row.insertCell(7).innerHTML = '<input style="height: 35px;width: 80px;line-height: 0;padding: 0;" type="button" value = "Delete" onClick="Javacsript:deleteRow(this)">';
    $("#frmBillDesc")[0].reset();
}

function deleteRow(obj) {

    var index = obj.parentNode.parentNode.rowIndex;
    var table = document.getElementById("tblBillingDesc");
    table.deleteRow(index);
    addSerialNumber();
    addSerialNumber();

}



function EditRow(obj) {

    $("#frmBillDesc")[0].reset();
    $("#Description").val(obj.parentNode.parentNode.cells[1].innerText);
    $("#Packing").val(obj.parentNode.parentNode.cells[2].innerText);
    $("#RatePerPacking").val(obj.parentNode.parentNode.cells[3].innerText);
    $("#NoOfPacking").val(obj.parentNode.parentNode.cells[4].innerText);
    $("#Amount").val(obj.parentNode.parentNode.cells[5].innerText);

    var index = obj.parentNode.parentNode.rowIndex;
    var table = document.getElementById("tblBillingDesc");
    table.deleteRow(index);
    $("#hdnRowIndex").val(index);
    //addSerialNumber();
}


var addSerialNumber = function () {
    var i = 0;
    $('table tr:not(:first-child)').each(function (index) {
        $(this).find('td:nth-child(1)').html(index  + 1);
    });
};



function addTable() {
    var myTableDiv = document.getElementById("myDynamicTable");
    var table = document.createElement('TABLE');
    table.border = '1';
    var tableBody = document.createElement('TBODY');
    table.appendChild(tableBody);

    for (var i = 0; i < 3; i++) {
        var tr = document.createElement('TR');
        tableBody.appendChild(tr);
        for (var j = 0; j < 4; j++) {
            var td = document.createElement('TD');
            td.width = '75';
            td.appendChild(document.createTextNode("Cell " + i + "," + j));
            tr.appendChild(td);
        }
    }
    myTableDiv.appendChild(table);
}

function load() {

    console.log("Page load finished");

}


function printDiv(divName) {
    debugger;
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}