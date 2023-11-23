var empObject = {};
var tourIdGlobal = 0;
//var empId = 1;
/// Code to Load TourRequest and Its Details Click Start from Here

function loadDataFromXLToForm(response) {
    this.parseExcel = function (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var data = e.target.result;
            var workbook = XLSX.read(data, {
                type: 'binary'
            });
            workbook.SheetNames.forEach(function (sheetName) {
                var XL_row_object = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
                var productList = JSON.parse(JSON.stringify(XL_row_object));
                var tableFinanceBulkApprovalDownLoads = $("#tableFinanceBulkApprovalDownLoads");
                tableFinanceBulkApprovalDownLoads.empty();
                tableFinanceBulkApprovalDownLoads.append(`<tr><th>SN</th><th>Id</th><th>EmpCode</th><th>Emp Name</th><th>Amount</th><th>SAP Reference</th><th>SAP Ref Date</th></tr>`);
                var tbodyDownloadList = $("#tbodyDownloadList");
                tbodyDownloadList.empty();
                //<td>
                //    <div class="form-check">
                //        <label class="form-check-label">
                //            <input id="checkboxSelect_${count}" type="checkbox" class="form-check-input">
                //        </label>
                //    </div>
                //</td>

                // console.log(productList)
                var count = 0;
                for (i = 0; i < productList.length; i++) {
                    var columns = Object.values(productList[i])
                    debugger;
                    var actualRow = response.data.find(e => e.id == columns[1])

                    var trTable = `<tr id="trtbodyDownloadList_${count}">
                                        
                                        <td>
                                                    ${columns[0]}

                                        <input value="${actualRow.employeeId}" type="hidden" id="inputEmpIdHidden_${count}" />
                                    <input value="${actualRow.id}" type="hidden" id="inputIdHidden_${count}" />

                                        </td>
                                        <td id="tdEmpCode_${count}">
                                                    ${columns[2]}
                                        </td>
                                        <td id="tdEmpName_${count}">
                                                    ${columns[3]}
                                        </td>
                                        <td id="tdApprovedBy_${count}">
                                            ${actualRow.approverDetails.approvedBy}
                                            <br />
                                            <span id="tdApprovedByDesignation_${count}" style="font-size:10px">( ${actualRow.approverDetails.designation})</span>
                                        </td>
                                        <td id="tdTypeOfPayment_${count}">
                                             Advance
                                        </td>
                                        <td id="tdAmountPayable_${count}">
                                             ${columns[4]}
                                        </td>
                                        <td>
                                            <a id="anchorViewFile_${count}" style="border:unset;width:auto;padding:0" target="_blank" href=" ${actualRow.approverDetails.filePath}" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File</a>
                                        </td>
                                        <td>
                                            <input value="${columns[5]}" id="inputSAPReference_${count}" type="text" class="form-control form-control-sm" />
                                        </td>
                                        <td>
                                            <input value="${formatDate_yyyy_mm_dd(new Date(Date.parse(columns[6])))}" id="inputSAPDate_${count}" type="date" class="form-control" >
                                        </td>
                                       
                                    </tr>`;
                    tbodyDownloadList.append(trTable);
                    count++;
                }
                //<td>
                //    <button id="btnEdit_${count}" onclick="btnEdit_Click(this,${count})" type="button" class="btn btn-primary elipse-btn"><i class="fa-solid fa-wand-magic-sparkles"></i> Edit</button>
                //</td>

            })
        };
        reader.onerror = function (ex) {
            console.log(ex);
        };

        reader.readAsBinaryString(file);
    };
    var files = evtGlobal.target.files; // FileList object
    //var xl2json = new ExcelToJSON();
    this.parseExcel(files[0]);

}
var ExcelToJSON = function () {
    getDataFromApi(false, loadDataFromXLToForm);
};

var evtGlobal = '';
function handleFileSelect(evt) {
    evtGlobal = evt;
  //var files = evt.target.files; // FileList object
  var xl2json = new ExcelToJSON();
  //xl2json.parseExcel(files[0]);
}
function getRecipienetIdOfFinanceBanking() {
    return 5;
}
function btnUpdate_All(e) {
    
    var objArr = [];
    debugger;
    for (var e of $('#tbodyDownloadList > tr')) {
        var i = e.id.split('_')[1];
        var obj = {
            "id": parseInt($("#inputIdHidden_"+i).val()),
            "employeeId": parseInt($("#inputEmpIdHidden_" + i).val()),
            "employeeCode": parseInt($("#tdEmpCode_" + i).html()).toString(),
            "sapReference": $("#inputSAPReference_" + i).val(), 
            "sapDate": formatDate_yyyy_mm_dd(new Date(Date.parse($("#inputSAPDate_" + i).val())))
        }
        //"sapReference": $("#inputSAPReference_" + i).val(),
        //    "sapDate": $("#inputSAPDate_" + i).val()
        objArr.push(obj);
    }
    //console.log(objArr);
   
    debugger;
    var _url = apiBaseUrl + "​​​​/api​/BulkApproval​/UploadBillPassingBulkApproval​/" + empObject.empId.toString() + "/" + getRecipienetIdOfFinanceBanking().toString();
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    debugger;
    $.ajax({
        type: "POST",
        url: _url,
        data: JSON.stringify(objArr),
        contentType: 'application/json',
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Success !',
                    text: "Your request is submited successfully and transferred to payment processing Team",
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });
}
function btnEdit_Click(e, index) {
    alert('working Edit Button');
}
var serverResponse = {};
function loadDataIntoTable(response) {
    var tableFinanceBulkApprovalDownLoads = $("#tableFinanceBulkApprovalDownLoads");
    tableFinanceBulkApprovalDownLoads.empty();
    tableFinanceBulkApprovalDownLoads.append(`<tr><th>SN</th><th>Id</th><th>EmpCode</th><th>Emp Name</th><th>Amount</th><th>SAP Reference</th><th>SAP Ref Date</th></tr>`);

    var tbodyDownloadList = $('#tbodyDownloadList');
    tbodyDownloadList.empty();
    var count = 0;
    //<td>
                                //    <div class="form-check">
                                //        <label class="form-check-label">
                                //            <input id="checkboxSelect_${count}" type="checkbox" class="form-check-input">
                                //        </label>
                                //    </div>
                                //</td>
    for(var e of response.data) {
        var trTable = ` <tr><td>${count + 1}</td><td>${e.id}</td><td>${e.employeeCode}</td><td> ${e.empoyeeName}</td><td> ${e.approvedAmount}</td><td></td><td></td></tr>`;
        var rowApproved = `<tr id="trtbodyDownloadList_${count}">
                                
                                <td>
                                    ${count + 1}

                                    <input value="${e.employeeId}" type="hidden" id="inputEmpIdHidden_${count}" />
                                    <input value="${e.id}" type="hidden" id="inputIdHidden_${count}" />
                                
                                </td>
                                <td id="tdEmpCode_${count}">
                                    ${e.employeeCode}
                                </td>
                                <td id="tdEmpName_${count}">
                                    ${e.empoyeeName}
                                </td>
                                <td id="tdApprovedBy_${count}">
                                    ${e.approverDetails.approvedBy}
                                    <br />
                                    <span id="tdApprovedByDesignation_${count}" style="font-size:10px">( ${e.approverDetails.designation})</span>
                                </td>
                                <td id="tdTypeOfPayment_${count}">
                                     Advance
                                </td>
                                <td id="tdAmountPayable_${count}">
                                     ${e.approvedAmount}
                                </td>
                                <td>
                                    <a id="anchorViewFile_${count}" style="border:unset;width:auto;padding:0" target="_blank" href=" ${e.approverDetails.filePath}" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File</a>
                                </td>
                                <td>
                                    <input value="" id="inputSAPReference_${count}" type="text" class="form-control form-control-sm" />
                                </td>
                                <td>
                                    <input value="" id="inputSAPDate_${count}" type="date" class="form-control" >
                                </td>
                                <td>
                                    <button id="btnEdit_${count}" onclick="btnEdit_Click(this,${count})" type="button" class="btn btn-primary elipse-btn"><i class="fa-solid fa-wand-magic-sparkles"></i> Edit</button>
                                </td>
                            </tr>`;
        tbodyDownloadList.append(rowApproved);
        tableFinanceBulkApprovalDownLoads.append(trTable);
        count++;

    }
}
function getDataFromApi(loadRequird, callBack) {
    //debugger;

    //alert('Not running Api Call due to Return ');        
    var url = apiBaseUrl + "​/api​/BulkApproval​/GetBillPassingBulkApproval​/" + empObject.empId.toString();
    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    $.ajax({
        type: "GET",
        url: url,
        //data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSeend: function () {
            $('.page-loader').show();

        },
        success: function (response) {
            /*console.log(response)
            console.log(response.statusCode)*/
            serverResponse = response;
            if (loadRequird)
                loadDataIntoTable(response, loadRequird);
            else
                callBack(response);

            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function loadDownLoadListRequestedList(loadRequired) {
    //AssociatedDiv: divTourApprovalPendingList
    // tbody id: tbodyApprovalPendingList    
    getDataFromApi(loadRequired, null);
}
function dowonloadXl_Click(e) {
    
}
$(document).ready(function () {
    empObject = setEmpObjectFromSessionStorage();
    document.getElementById('fileupload').addEventListener('change', handleFileSelect, false); 
    loadDownLoadListRequestedList(true);

});