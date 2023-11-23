var empObject = {};
var tourIdGlobal = 0;
var claimTypeIdGlobal = 0;
var requesterEmpIdGlobal = 0;
var managerIdGlobal = 0;
function getEmployeeListFromOrganization() {
    function getDataFromApi() {
        var datalistApprovers = $('#approvres');
        //alert('Not running Api Call due to Return ');        
        var url = "https://uat.dfccilorganization.services.cetpainfotech.com/api/Organization/GetOrganizationHierarchy";
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
                datalistApprovers.empty();
                var count = 1;
                debugger;
                $.each(response.data, function () {
                    var row = `<option data-managerId="${this.managerId}" data-managerCode="${this.managerCode}" data-empCode="${this.empCode}" data-empId="${this.empId}" value="${this.empName} (${this.designation
                        }, ${this.department})">${this.empName} (${this.designation},  ${this.department})</option>`;
                    datalistApprovers.append(row);
                    count++;
                });
                // alert('Data Loded');
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    getDataFromApi();
}
//var empId = 1;
/// Code to Load TourRequest and Its Details Click Start from Here
function loadTourRequestedList() {
    //AssociatedDiv: divTourApprovalPendingList
    // tbody id: tbodyApprovalPendingList
    function getDataFromApi() {
        var tbodyApprovalPendingList = $('#tbodyApprovalPendingList');
        //alert('Not running Api Call due to Return ');        
        var url = apiBaseUrl + "/api/TourListing/GetRecipientTourRequest/" + empObject.empId.toString();
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
                $.each(response.data, function () {
                    if (this.status != 'Approved') {

                        var rowTourPending = `  <tr>
                            <td>${count}</td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.requestDate)))}
                            </td>
                            <td>${this.empName}</td>
                            <td> ${this.purposeofTour}</td>
                            <td>  ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.tourStartDate)))}</td>
                            <td> ${this.source}</td>
                            <td> ${this.destination}</td>
                            <td> ${this.totalDays}</td>
                            <td> <button onclick="btnEmpDetails_Click(${this.tourId},${this.empId})" class="btn btn-commen btn-color" type="button">Details</button></td>
                        </tr>`;
                        tbodyApprovalPendingList.append(rowTourPending);
                        count++;
                    }
                });
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
var IsRoad = false;
var IsTrain = false;
var IsAir = false;
var isDirector = false;
var isAdvance = false;
function btnEmpDetails_Click(tourId,empId) {
    tourIdGlobal = tourId;
    requesterEmpIdGlobal = empId;
    IsRoad = false;
    IsTrain = false;
    IsAir = false;
    function callApitoLoadDetailsForATour(tourId) {
        function loadTentativeTourPlan(dataTentativePlan) {
            var tbodyTentativePlan = $('#tbodyTentativePlan');
            tbodyTentativePlan.empty();
            var count = 1;
            $.each(dataTentativePlan, function () {
                if (this.travelMode.toUpperCase().includes('RAIL'))
                    IsTrain = true;
                if (this.travelMode.toUpperCase().includes('ROAD'))
                    IsRoad = true;
                if (this.travelMode.toUpperCase().includes('AIR'))
                    IsAir = true;

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
            $("#spanTentativeStartDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse( dataEmployee.tentativeStartDate))));
            $("#spanNoOfDays").html(dataEmployee.noOfDays);
            $("#spanUnits").html(dataEmployee.units);
            
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
                loadTentativeTourPlan(response.data.tentativeTourPlans);
                loadEmployeeDetails(response.data.employeeDetails);
                if (response.data.isAdvanceRequired) {
                    isAdvance = true;
                    claimTypeIdGlobal = 1;
                }
                else {
                    isAdvance = false;
                    claimTypeIdGlobal = 4;
                }
                if (IsRoad || IsAir) {
                    if (isDirector) {
                        $("#divDirectApprovedOrReject").css('display', 'block');
                        $("#divSelectApprover").css('display', 'none');
                    }
                    else {
                        $("#divDirectApprovedOrReject").css('display', 'none');
                        $("#divSelectApprover").css('display', 'block');

                    }
                }
                else {
                    $("#divDirectApprovedOrReject").css('display', 'block');
                    $("#divSelectApprover").css('display', 'none');
                }
                
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    $("#divEmployeeDetails").css('display', 'block');
    $("#divTentativeTourPlanDetails").css('display', 'block');
    $("#divApprovalAndConfirmation").css('display', 'block');

    
    callApitoLoadDetailsForATour(tourId);
   
}

/// Code to Load Details for a Employee Ends Here

/// Code to Submit Details on Server Start from Here
// for Tour Approval we Have to Send Finanace Id in case approved 
var financeIdGLobal = 225;// login Id EMPCode 100430
function btnApprove_Reject_Approval_Click(e, type) {
    alert('Ready to Post Data for ' + type);
    debugger;
    const formDataNew = new FormData();
    formDataNew.append('TourId', parseInt(tourIdGlobal));
    formDataNew.append('EmpId', parseInt(empObject.empId));    
    formDataNew.append('ClaimTypeId', parseInt(claimTypeIdGlobal));
    
    if (type == 'Approve') {
        
        
        if (isAdvance) {
            formDataNew.append('StatusId', 3);
            formDataNew.append('RecipientId', parseInt(financeIdGLobal));
        }
        else {
            formDataNew.append('StatusId', 2);
            formDataNew.append('RecipientId', parseInt(requesterEmpIdGlobal));
        }
        
    }
    else if (type == 'Reject') {
        formDataNew.append('StatusId', 5);
        formDataNew.append('RecipientId', parseInt(requesterEmpIdGlobal));
    }
    else if (type == 'Approval') {
        formDataNew.append('StatusId', 6);
        formDataNew.append('RecipientId', parseInt(empIdFromOrganization));
    }
    
    //var _url = 'https://uat.dfccil.services.cetpainfotech.com/api/Claim/AdvanceRequest​';
    var _url = apiBaseUrl + "​​/api​/TourStatus​/Update​/TourRequestStatus";
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
var managerIdFromOrganization = 0;
var managerCodeFromOrganization = 0;
var empIdFromOrganization = 0;
var empCodeFromOrganization = 0;
$(document).ready(function () {
    empObject = setEmpObjectFromSessionStorage();
    if (empObject.empDesignation.includes('DIRECTOR')) {
        isDirector = true;
    }
    else {
        isDirector = false
    }
    getEmployeeListFromOrganization();
    loadTourRequestedList()

    $("#input-datalist").change(function () {
        var el = $("#input-datalist")[0];  //used [0] is to get HTML DOM not jquery Object
        var dl = $("#approvres")[0];
        if (el.value.trim() != '') {
            var opSelected = dl.querySelector(`[value="${el.value}"]`);
            managerIdFromOrganization = opSelected.getAttribute('data-managerId');
            managerCodeFromOrganization = opSelected.getAttribute('data-managerCode');
            empIdFromOrganization = opSelected.getAttribute('data-empId');
            empCodeFromOrganization = opSelected.getAttribute('data-empCode');;
        }
    });

});