var empObject = {};
var tourIdGlobal = 0;
//var empId = 1;
/// Code to Load TourRequest and Its Details Click Start from Here
function loadTourRequestedList() {
    //AssociatedDiv: divTourApprovalPendingList
    // tbody id: tbodyApprovalPendingList
    function getDataFromApi() {
        //debugger;
        var tbodyApprovalPendingList = $('#tbodyApprovalPendingList');
        //alert('Not running Api Call due to Return ');        
        var url = apiBaseUrl + "​/api​/TourListing​/GetBillPassingList​/" + empObject.empId.toString();
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
                tbodyApprovalPendingList.empty();
                var count = 1;
                for (var e of response.data) {
                    if (e.status == 'Finance Processing') {
                        var rowTourPending = `  <tr>
                            <td>${count}</td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(e.requestDate)))}
                            </td>
                            <td>${e.empName}</td>
                            <td> ${e.purposeofTour}</td>
                            <td>  ${formatDate_dd_mm_yyyy(new Date(Date.parse(e.tourStartDate)))}</td>
                            <td> ${e.source}</td>
                            <td> ${e.destination}</td>
                            <td> ${e.totalDays}</td>
                            <td> <button onclick="btnEmpDetails_Click(${e.tourId},'${e.status}')" class="btn btn-commen btn-color" type="button">Details</button>
                                <a  href="${e.approverDetails.filePath}" target="_blank" class="btn btn-commen btn-color" >View Approval</a>
                            </td>

                        </tr>`;
                        tbodyApprovalPendingList.append(rowTourPending);
                        count++;
                    }
                }
               
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    getDataFromApi();
}

/// Code to Load TourRequest and Its Details Click Ends Here
/// Code to Load Details for a Employee Start from Here
//Code to View Files Starts from  Here
var documentDetails = { TourEstimate: [], AccommodationEstimate: [] }
function TrigerModalViewFile(type, type2) {
    $("#viewModal").modal('show');
    $("#modelTitle").html(type)
    $("#tbodyViewDocuments").empty();
    count = 1;
    for (let e of documentDetails[type2]) {
        let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e.pathUrl}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
        $("#tbodyViewDocuments").append(row)
        count++;
    }
}
//Code to View Files Ends  Here
//var IsRoad = false;
//var IsTrain = true;
//var IsAir = false;
//var isDirector = false;
function btnEmpDetails_Click(tourId, status) {
    tourIdGlobal = tourId;
    function callApitoLoadDetailsForATour(tourId) {
        function loadTentativeTourPlan(dataTentativePlan) {
            var tbodyTentativePlan = $('#tbodyTentativePlan');
            tbodyTentativePlan.empty();
            var count = 1;
            $.each(dataTentativePlan, function () {
                var rowTentativePlan = `  <tr>
                            <td>${count}</td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.date)))}
                            </td>                           
                            <td> ${this.from}</td>
                            <td> ${this.to}</td>
                            <td> ${this.travelMode}</td>
                            <td> ${this.classOfCity}</td>
                            <td> ${this.remark}</td>                            
                        </tr>`;
                tbodyTentativePlan.append(rowTentativePlan);
                count++;
            });

        }
        function loadEmployeeDetails(dataEmployee) {
            $("#spanEmployeeNo").html(dataEmployee.employeeNo);
            $("#spanEmployeeName").html(dataEmployee.employeeName);
            $("#spanEmpDesignation").html(dataEmployee.designation);
            $("#spanEmpPurpose").html(dataEmployee.purposeOfTour);
            $("#spanSource").html(dataEmployee.source);
            $("#spanDestination").html(dataEmployee.destination);
            $("#spanEmpDepartment").html(dataEmployee.employeeDepartment);
            $("#spanTentativeStartDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(dataEmployee.tentativeStartDate))));
            $("#spanNoOfDays").html(dataEmployee.noOfDays);
            $("#spanUnits").html(dataEmployee.units);

        }
        function loadApproverDetails(dataApprover) {
            $("#spanAdvanceApprovedDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(dataApprover.approvalDate))));

            $("#spanAdvanceApprovedBy").html(dataApprover.approvedBy);
            $("#spanAdvanceDesignation").html('(' + dataApprover.designation + ', ' + dataApprover.department + ')');
           // $("#spanAdvanceDesignation").html('(' + dataApprover.designation + ')');
            $("#anchorDownloadTourApproval").attr('href', dataApprover.filePath);

        }
        function loadTourPlanEstimate(isAdvance, dataTravelEstimate, dataAccomodationEstimate, advanceRequired = 0, approvedAdvance = 0) {
            $("#tdTravelEstimate").html(dataTravelEstimate.travelEstimateAmount);
            $("#tdAccomodationEstimate").html(dataAccomodationEstimate.accomodationEstimate);

            documentDetails.TourEstimate = dataTravelEstimate.travelFiles;
            $("#spanTourEstimateView").html(documentDetails.TourEstimate.length);
            documentDetails.AccommodationEstimate = dataAccomodationEstimate.accommodationFiles;
            $("#spanAccommodationEstimateView").html(documentDetails.AccommodationEstimate.length);

            $("#tdTotalEstimate").html(dataAccomodationEstimate.accomodationEstimate + dataTravelEstimate.travelEstimateAmount);


        }
        function loadApprovalDetails(advanceRequired = 0) {
            $("#spanAdvanceRequest").html(advanceRequired);

        }
        //var tbodyApprovalPendingList = $('#tbodyApprovalPendingList');
        //alert('Not running Api Call due to Return ');        
        var url = apiBaseUrl + "/api/TourPlan/GetTourDetails/" + tourId;
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
                if (status == 'Approved') {
                    $("#divApproverDetails").css('display', 'block');
                    loadApproverDetails(response.data.approverDetails);
                }
                else {
                    $("#divApproverDetails").css('display', 'none');

                }
                loadTentativeTourPlan(response.data.tentativeTourPlans);
                loadEmployeeDetails(response.data.employeeDetails);
                //loadApproverDetails(response.data.approverDetails, response.data.pdfPath);
                loadTourPlanEstimate(response.data.isAdvanceRequired, response.data.travelEstimate, response.data.accommodationEstimate);
                loadApprovalDetails(response.data.advanceRequired, response.data.isAdvanceRequired);

                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    $("#divEmployeeDetails").css('display', 'block');
    $("#divTentativeTourPlanDetails").css('display', 'block');
    $("#divApproverDetails").css('display', 'block');
    $("#divTravelEstimate").css('display', 'block');
    $("#divApprovalDetails").css('display', 'block');
    $("#divSendforBulkDownload").css('display', 'block');

    //$("#divApprovalAndConfirmation").css('display', 'block');

    debugger;
    //if (IsRoad || IsAir) {
    //    if (isDirector) {
    //        $("#divDirectApprovedOrReject").css('display', 'block');
    //        $("#divSelectApprover").css('display', 'none');
    //    }
    //    else {
    //        $("#divDirectApprovedOrReject").css('display', 'none');
    //        $("#divSelectApprover").css('display', 'block');

    //    }
    //}
    //else {
    //    $("#divDirectApprovedOrReject").css('display', 'block');
    //    $("#divSelectApprover").css('display', 'none');
    //}
    callApitoLoadDetailsForATour(tourId);

}
var btnSendforBulkDownload = document.getElementById('btnSendforBulkDownload');
function inputAdvanceApprovedAmount_OnFocusOut(e) {
    var amt = parseInt(e.value);
    if (isNaN(amt) || amt == undefined || amt <= 0) {
        amt = 0;
        e.value = 0;
        btnSendforBulkDownload.disabled = true;
        return;
    }
    
    var totalEstimate = parseInt($("#tdTotalEstimate").html());
    if (amt > totalEstimate) {
        e.value = totalEstimate;
        
        swal({
            title: 'Invalid !',
            text: "Approved Amount cant't Greater then Estimate Amount",
            type: 'info'
        });
        
        
    }
    btnSendforBulkDownload.disabled = false;
}
/// Code to Load Details for a Employee Ends Here

/// Code to Submit Details on Server Start from Here
function btnSendforBulkDownload_Click(e) {
    //alert('Post Started Now');
    const formDataNew = new FormData();
    formDataNew.append('EmpId', parseInt(empObject.empId));
    formDataNew.append('TourId', parseInt(tourIdGlobal));
    formDataNew.append('ClaimTypeId', 1);
    formDataNew.append('ApprovedAmount', parseInt($("#inputAdvanceApprovedAmount").val()));

    var _url = apiBaseUrl + "​​/api​/TourStatus​/Update​/TourRequestAmount";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "PUT",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Please wait..';
        },
        success: function (response) {
            debugger;

            if (response.statusCode == 201) {
                swal({
                    title: 'Sucess !',
                    text: 'Request has been successfully submitted!',
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
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Submit';
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Add';
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });
}
function btnApprove_Reject_Approval_Click(e, type) {
    alert('Ready to Post Data for ' + type);
    

    const formDataNew = new FormData();
    formDataNew.append('EmpId', parseInt(empObject.empId));
    formDataNew.append('TourId', parseInt(tourIdGlobal));
    formDataNew.append('ClaimTypeId', 1);
    formDataNew.append('ApprovedAmount', parseInt($("#inputAdvanceApprovedAmount").val()));    
    
    var _url = apiBaseUrl + "​​/api​/TourStatus​/Update​/TourRequestAmount";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "PUT",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Please wait..';
        },
        success: function (response) {
            debugger;

            if (response.statusCode == 201) {
                swal({
                    title: 'Sucess !',
                    text: 'Request has been successfully submitted!',
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
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Submit';
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            e.innerHTML = '<i class="fa-solid fa-plus"></i> &nbsp;Add';
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });
}
/// Code to Submit Details on Server Ends Here

$(document).ready(function () {
   empObject= setEmpObjectFromSessionStorage();
    loadTourRequestedList()

});