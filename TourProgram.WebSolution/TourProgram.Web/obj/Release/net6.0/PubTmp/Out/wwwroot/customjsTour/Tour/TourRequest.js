//Code to Upload Files Start From Here
var empObject = {};
var uploadType = '';
var uploadKey = '';
var fileData = [];
var uploadDetails = { TourEstimate: [], AccommodationEstimate: [] };
var imgUpload = document.getElementById('upload-img')
    , imgPreview = document.getElementById('img-preview')
    , imgUploadForm = document.getElementById('form-upload')
    , totalFiles
    , previewTitle
    , previewTitleText
    , img;

imgUpload.addEventListener('change', previewImgs, true);
var trBodyUploadDoc = document.getElementById('trBodyUploadDoc');
function loadUploadedFile(key) {
    var row = '';
    let count = 1;
    if (uploadDetails[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetails[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadType}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_file(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function previewImgs(event) {

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;
    debugger;
    uploadDetails[uploadKey].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    debugger;
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    imgUpload.value = null;
    loadUploadedFile(uploadKey);
}
function delete_file(index) {
    uploadDetails[uploadKey].splice(index, 1);
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    loadUploadedFile(uploadKey);
}

function TrigerModalUploadFile(type, type2) {
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFile(type2);
}

//Code to Upload Files Ends  Here
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


/// Code to Load TourRequest and Its Details Click Start from Here
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
                //debugger;
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
                $('.page-loader').hide();
            }
        });
    }
    getDataFromApi();
}
function loadTourRequestedList() {
    //AssociatedDiv: divTourRequestedList
    // tbody id: tbodyTourRequested

    function getDataFromApi() {
        var tbodyTourRequested = $('#tbodyTourRequested');
        //alert('Not running Api Call due to Return ');        
        var url = apiBaseUrl + "/api/TourListing/GetTourRequest/" + empObject.empId.toString();
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
                tbodyTourRequested.empty();
                var count = 1;
                $.each(response.data, function () {
                    let statusColorClass = 'badge-success';
                    let disabled = 'disabled';
                    if (this.statusId == 1) {
                        statusColorClass = 'badge-warning';
                        disabled = 'disabled';
                    }
                    else if (this.statusId == 7) {
                        disabled = 'disabled';
                        statusColorClass = 'badge-danger'
                    }
                    else if (this.statusId == 5) {
                        disabled = 'disabled';
                        statusColorClass = 'badge-danger'
                    }
                    else if (this.statusId == 2) {
                        disabled = '';
                        statusColorClass = 'badge-success'
                    }
                    else if (this.statusId == 9) {
                        disabled = '';
                        statusColorClass = 'badge-success'
                    }
                    else {
                        disabled = 'disabled';
                        statusColorClass = 'badge-warning';
                    }
                    if (this.statusId != 9) {
                        var rowTourRequested = ` <tr>
                            <td>${count}</td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.requestDate)))}
                            </td>
                            <td>
                                ${this.purposeofTour}
                            </td>
                            <td>
                                ${formatDate_dd_mm_yyyy(new Date(Date.parse(this.tourStartDate)))}
                            </td>
                            <td>
                                ${this.totalDays}
                            </td>
                            <td>
                                 ${this.source}
                            </td>
                            <td>
                                 ${this.destination}
                            </td>
                            <td class="font-weight-medium"><div class="badge ${statusColorClass}">${this.status}</div></td>

                            <td><button onclick="tourDetails_Click(${this.tourId},'${this.status}','${this.statusId}')" type="button" id="btnDetails" class="btn btn-primary mb-2">Details</button>
                            <button ${disabled} onclick="tourCancel_Click(${this.tourId},'${this.status}')" type="button" id="btn" class="btn btn-danger mb-2">Tour Not Availed</button>
                            </td>
                            
                        </tr>`;

                        tbodyTourRequested.append(rowTourRequested);
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
function tourCancel_Click(tourId) {
    alert('Now we are going to cancel tour');
}
function setDefaultValueToTentativeTourPlan() {
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    tbodyTentativePlan.empty();
    tbodyTentativePlan.append(` <tr id="trTentativePlan_0">
                            <td>
                                <input id="inputStartDate_0" type="date" class="form-control">
                            </td>
                            <td>
                                <input id="inputFrom_0" type="text" class="form-control">
                            </td>
                            <td>
                                <input id="inputTo_0" type="text" class="form-control">
                            </td>
                            <td>
                                <select id="selectTravelMode_0" class="form-control mode">
                                    <option>Air</option>
                                    <option>Rail</option>
                                    <option>Road</option>

                                </select>
                            </td>
                            <td>
                                <select id="selectClassOfCity_0" class="form-control mode">
                                    <option value="X">X</option>
                                    <option value="Y">Y</option>
                                    <option value="Z">Z</option>

                                </select>
                            </td>
                            <td>
                                <input id="inputTourDetails_0" type="text" class="form-control">
                            </td>
                            <td>
                                <button onclick="btnplus_0_Click(this)" type="button" id="btnplus_0" class="btn btn-primary"><i class="fa fa-plus" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button disabled type="button" id="btnminus_0" class="btn btn-primary"><i class="fa fa-minus" aria-hidden="true"></i></button>
                            </td>

                        </tr>`);
}
function setDefaultvalueOfTourProgram() {
    $("#inputPurposeOfTravel").val('');
    $("#inputSource").val('');
    $("#inputDestination").val('');
    $("#inputTentativeDateOfDeparture").val('');
    $("#inputNumberOfDays").val('');
}
function setDefaultToAdvance() {
    $("#inputTravelEstimate").val(0);
    $("#inputAccommodationEstimate").val(0);
    $("#inputAdvanceRequired").val(0);
    $("#tdTotalEstimate").html(0);
    $("#inputAdvanceRequired").val(0);
    $("#radioAdvanceRequiredYes").prop('checked', false);
    $("#radioAdvanceRequiredNo").prop('checked', true);
    $("#divTourEstimate").css('display', 'none');
}

function tourDetails_Click(tourId, status, statusId) {
    //alert(tourId);
    $("#divTourProgram").css('display', 'block');
    $("#divTentativeTourPlan").css('display', 'block');
    $("#divAdvanceRequired").css('display', 'block');
    $("#divDeclaration").css('display', 'none');
    $("#divSelectApprover").css('display', 'none');
    
    function loadApproverDetails(dataApprover) {
        $("#spanAdvanceApprovedDate").html(formatDate_dd_mm_yyyy(new Date(Date.parse(dataApprover.approvalDate))));

        $("#spanAdvanceApprovedBy").html(dataApprover.approvedBy);
        $("#spanAdvanceDesignation").html('(' + dataApprover.designation + ', ' + dataApprover.department +')');
        $("#anchorDownloadTourApproval").attr('href', dataApprover.filePath);

    }
    function loadTourProgram(dataTourProgram) {
        $("#inputPurposeOfTravel").val(dataTourProgram.purposeOfTour);
        $("#inputSource").val(dataTourProgram.source);
        $("#inputDestination").val(dataTourProgram.destination);
        $("#inputTentativeDateOfDeparture").val(formatDate(new Date(Date.parse(dataTourProgram.tentativeStartDate))));
        $("#inputNumberOfDays").val(dataTourProgram.noOfDays);
       
    }
    function loadTentativeTourPlan(dataTentativeTour) {
        //setDefaultValueToTentativeTourPlan();
        var tbodyTentativePlan = $("#tbodyTentativePlan");
        tbodyTentativePlan.empty();
        debugger;
        for (var i = 0; i < dataTentativeTour.length; i++) {
            var row = ` <tr id="trTentativePlan_${i}">
                            <td>
                                <input id="inputStartDate_${i}" type="date" value="${formatDate(new Date(Date.parse(dataTentativeTour[i].date)))}" class="form-control">
                            </td>
                            <td>
                                <input id="inputFrom_${i}" type="text" value="${dataTentativeTour[i].from}" class="form-control">
                            </td>
                            <td>
                                <input id="inputTo_${i}" type="text" value="${dataTentativeTour[i].to}" class="form-control">
                            </td>
                            <td>
                                <select id="selectTravelMode_${i}"  value="${dataTentativeTour[i].travelMode}" class="form-control mode">
                                    <option value="Air">Air</option>
                                    <option value="Rail">Rail</option>
                                    <option value="Road">Road</option>

                                </select>
                            </td>
                            <td>
                                <select id="selectClassOfCity_${i}"   class="form-control mode">
                                    <option value="X">X</option>
                                    <option value="Y">Y</option>
                                    <option value="Z">Z</option>

                                </select>
                            </td>
                            <td>
                                <input id="inputTourDetails_${i}" type="text"  class="form-control">
                            </td>
                            <td>
                                <button disabled onclick="btnplus_0_Click(this)" type="button" id="btnplus_0" class="btn btn-primary"><i class="fa fa-plus" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button disabled type="button" id="btnminus_0" class="btn btn-primary"><i class="fa fa-minus" aria-hidden="true"></i></button>
                            </td>
                            
                        </tr>`;
            tbodyTentativePlan.append(row);
            $('#selectTravelMode_' + i).val(dataTentativeTour[i].travelMode);
            $('#selectClassOfCity_' + i).val(dataTentativeTour[i].classOfCity);
            //for (var e of tbodyTentativePlan.getElementById('selectTravelMode_${i}').options) {
            //    if (e.value == dataTentativeTour[i].travelMode) {
            //        e.selected = true;
            //    }
            //}
        }
    }
    function loadAdvanceValue(isAdvance, dataTravelEstimate, dataAccomodationEstimate,advanceRequired=0,approvedAdvance=0) {
        if (isAdvance) {
            getDataFromGradeApi();
            $("#btnTourEstimate").css('display','none')
            $("#btnTourEstimateView").css('display', 'block')
            $("#btnAccommodationEstimate").css('display', 'none')
            $("#btnAccommodationEstimateView").css('display', 'block')

            $("#radioAdvanceRequiredYes").prop('checked', true);
            $("#radioAdvanceRequiredNo").prop('checked', false);
            $("#divTourEstimate").css('display', 'block');

            $("#inputTravelEstimate").val(dataTravelEstimate.travelEstimateAmount);
            $("#inputAccommodationEstimate").val(dataAccomodationEstimate.accomodationEstimate);
            $("#inputAdvanceRequired").val(advanceRequired);
            documentDetails.AccommodationEstimate = dataAccomodationEstimate.accommodationFiles;
            $("#spanAccommodationEstimateView").html(documentDetails.AccommodationEstimate.length);
            documentDetails.TourEstimate = dataTravelEstimate.travelFiles;
            $("#spanTourEstimateView").html(documentDetails.TourEstimate.length);
            $("#tdTotalEstimate").html(dataAccomodationEstimate.accomodationEstimate + dataTravelEstimate.travelEstimateAmount);

        }
        else {
            $("#radioAdvanceRequiredYes").prop('checked', false);
            $("#radioAdvanceRequiredNo").prop('checked', true);
            $("#divTourEstimate").css('display', 'none');

            $("#btnTourEstimate").css('display', 'none')
            $("#btnTourEstimateView").css('display', 'none')
            $("#btnAccommodationEstimate").css('display', 'none')
            $("#btnAccommodationEstimateView").css('display', 'none')
        }
    }
    function getDataFromApiForATourId(tourId) {

        var url = apiBaseUrl + "/api/TourPlan/GetTourDetails/" + tourId.toString();
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
                debugger;
                if (statusId == 2) {
                    $("#divApproverDetails").css('display', 'block');
                    loadApproverDetails(response.data.approverDetails);
                }
                else {
                    $("#divApproverDetails").css('display', 'none');

                }
                loadTourProgram(response.data.employeeDetails);
                loadTentativeTourPlan(response.data.tentativeTourPlans);
                loadAdvanceValue(response.data.isAdvanceRequired, response.data.travelEstimate, response.data.accommodationEstimate, response.data.advanceRequired);
                $('.page-loader').hide();

            },
            failure: function (response) {
                alert(response.d);
            }
        });

    }
    getDataFromApiForATourId(tourId);
}
/// Code to Load TourRequest and Its Details Click Ends Here
/// Code for TenTative Tour Plan Start from Here
function IsValidData(v) {
    debugger;
    if (v == undefined  || v == null || v == '')
        return false;
    else
        return true;
}
var lastRowTo = '';
function readAllRow() {
    var Isvalid = true;
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    var v = '';
    tbodyTentativePlan.find('tr').each(function () {
        var i = this.id.split('_')[1];
        v = document.getElementById('inputStartDate_' + i).value;
        if (!IsValidData(v)) {
            swal({
                title: 'Invalid !',
                text: 'Please Enter Valid Start Date',
                type: 'error'
            });
            $("#inputStartDate_" + i).focus();
            Isvalid = false;
            return false;
        }
        v = document.getElementById('inputFrom_' + i).value;
        if (!IsValidData(v)) {
            swal({
                title: 'Invalid !',
                text: 'Please Enter Valid Source(From) Location',
                type: 'error'
            });
            $("#inputFrom_" + i).focus();
            Isvalid = false;
            return false;
        }
        v = document.getElementById('inputTo_' + i).value;
        lastRowTo = v;
        if (!IsValidData(v)) {
            swal({
                title: 'Invalid !',
                text: 'Please Enter Valid Destination(To) Location',
                type: 'error'
            });
            $("#inputTo_" + i).focus();
            Isvalid = false;
            return false;
        }
        //v = document.getElementById('inputTourDetails_' + i).value;
        //if (!IsValidData(v)) {
        //    swal({
        //        title: 'Invalid !',
        //        text: 'Please Enter Valid Tour Details',
        //        type: 'error'
        //    });
        //    $("#inputTourDetails_" + i).focus();
        //    Isvalid = false;
        //    return false;
        //}
       
        //alert(this.id);
    });
    return Isvalid;
}
var rowIndexTentativePlan = 0;
function btnplus_0_Click(e) {
    if (!readAllRow())
        return;
    // tbodyId=  tbodyTentativePlan
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    // e.disabled = true;
    rowIndexTentativePlan++;
    var row = ` <tr id="trTentativePlan_${rowIndexTentativePlan}">
                            <td>
                                <input id="inputStartDate_${rowIndexTentativePlan}" type="date" class="form-control">
                            </td>
                            <td>
                                <input id="inputFrom_${rowIndexTentativePlan}" type="text" value="${lastRowTo}" class="form-control">
                            </td>
                            <td>
                                <input id="inputTo_${rowIndexTentativePlan}" type="text" class="form-control">
                            </td>
                            <td>
                                <select id="selectTravelMode_${rowIndexTentativePlan}" class="form-control mode">
                                    <option>Air</option>
                                    <option>Rail</option>
                                    <option>Road</option>

                                </select>
                            </td>
                            <td>
                                <select id="selectClassOfCity_${rowIndexTentativePlan}" class="form-control mode">
                                    <option value="X">X</option>
                                    <option value="Y">Y</option>
                                    <option value="Z">Z</option>

                                </select>
                            </td>
                            <td>
                                <input id="inputTourDetails_${rowIndexTentativePlan}" type="text" class="form-control">
                            </td>
                            <td>
                                <button onclick="btnplus_0_Click(this)" type="button" id="btnplus_0" class="btn btn-primary"><i class="fa fa-plus" aria-hidden="true"></i></button>
                            </td>
                            <td>
                                <button onclick="btnminus_Click(this,${rowIndexTentativePlan})" type="button" id="btnminus_${rowIndexTentativePlan}" class="btn btn-primary"><i class="fa fa-minus" aria-hidden="true"></i></button>
                            </td>
                        </tr>`;
    tbodyTentativePlan.append(row);

}
function btnminus_Click(e,rowIndex) {
    $("#trTentativePlan_" + rowIndex).remove();
}
/// Code for TenTative Tour Plan Start from Ends Here
function onLoadPageVisibility() {
    $("#divTourProgram").css('display', 'none');
    $("#divTentativeTourPlan").css('display', 'none');
    $("#divAdvanceRequired").css('display', 'none');
    $("#divGradeDetails").css('display', 'none');
    $("#divTourEstimate").css('display', 'none');
    $("#divDeclaration").css('display', 'none');
}
function btnNewTourRequest_Click(e) {
    $("#divTourProgram").css('display', 'block');
    $("#divTentativeTourPlan").css('display', 'block');
    $("#divAdvanceRequired").css('display', 'block');
    $("#divDeclaration").css('display', 'block');
    $("#divSelectApprover").css('display', 'block');
    setDefaultValueToTentativeTourPlan();
    setDefaultvalueOfTourProgram();
    setDefaultToAdvance();
    $("#btnTourEstimate").css('display', 'block')
    $("#btnTourEstimateView").css('display', 'none')
    $("#btnAccommodationEstimate").css('display', 'block')
    $("#btnAccommodationEstimateView").css('display', 'none')
}
var gradeData = null;
var empGrade = 'N1';
function getDataFromGradeApi() {
    if (gradeData != null) {
        loadGradeData();
        return;
    }

    //alert('Not running Api Call due to Return ');        
    var url = apiBaseUrl + "/api/TourPlan/GetGradeDetail?lavel=" + empObject.empGrade;
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
            gradeData = { lavel: response.data[0].lavel, X: response.data[0].x, Y: response.data[0].y, Z: response.data[0].z }
            loadGradeData();

            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function loadGradeData() {
    var tbodyGrade = $('#tbodyGrade');
    tbodyGrade.empty();
    var row = `<td>
                                ${gradeData.lavel}
                            </td>
                            <td>
                                ${gradeData.X}
                            </td>
                            <td>
                                  ${gradeData.Y}
                            </td>
                            <td>
                                 ${gradeData.Z}
                            </td>
                        </tr>`;
    tbodyGrade.append(row);
}
function radioAdvanceRequired_Click(e, type) {
   
    
    if (type == "Yes") {
        $("#divGradeDetails").css('display', 'block');
        $("#divTourEstimate").css('display', 'block');
        getDataFromGradeApi();
    }
    else {
        $("#divGradeDetails").css('display', 'none');
        $("#divTourEstimate").css('display', 'none');
    }
}

function calculateEstimate_FocusOut(e) {
    var inputTravelEstimate = document.getElementById('inputTravelEstimate');
    var inputAccommodationEstimate = document.getElementById('inputAccommodationEstimate');
    var amtTravel = parseInt(inputTravelEstimate.value);
    var amtAccomodation = parseInt(inputAccommodationEstimate.value);
    if (isNaN(amtTravel) || amtTravel == undefined || amtTravel == null) {
        inputTravelEstimate.value = 0;
        amtTravel = 0;
    }
    if (isNaN(amtAccomodation) || amtAccomodation == undefined || amtAccomodation == null) {
        inputAccommodationEstimate.value = 0;
        amtAccomodation = 0;
    }
    $("#tdTotalEstimate").html(amtTravel + amtAccomodation);

        
}
function inputAdvanceRequired_focusOut(e) {
    var amt = parseInt(e.value);
    var amtEstimate = $("#tdTotalEstimate").html();
    if (isNaN(amt) || amt == undefined || amt == null) {
        e.value = 0;
        amt = 0;
    }
    if (isNaN(amtEstimate) || amtEstimate == undefined || amtEstimate == null) {
        
        amtEstimate = 0;
    }
    if (amt > amtEstimate) {
        e.value = amtEstimate;
        swal({
            title: 'Invalid !',
            text: "Advance Requested Amount can't be Greater Then Estimated Amount",
            type: 'info'
        });
    }

}
function checkDeclaration_cick(e) {
    if (e.checked) {
        $("#btnTourPlanSubmit").prop('disabled', false);
    }
    else {
        $("#btnTourPlanSubmit").prop('disabled', true);

    }
}

function createPostdataTourPlan() {
    var tourData = [];
    var tbodyTentativePlan = $("#tbodyTentativePlan");
    
    tbodyTentativePlan.find('tr').each(function () {
        var i = this.id.split('_')[1];
        var startDate = document.getElementById('inputStartDate_' + i).value;
        
        var from = document.getElementById('inputFrom_' + i).value;
        
        var to= document.getElementById('inputTo_' + i).value;

        var mode = document.getElementById('selectTravelMode_' + i).value
        var classOfCity = document.getElementById('selectClassOfCity_' + i).value
        
        var tourdetails = document.getElementById('inputTourDetails_' + i).value;
        tourData.push({
            date: startDate,
            from: from,
            to: to,
            travelMode: mode,
            tourDetails: tourdetails,
            classOfCity: classOfCity
        })
        
        //alert(this.id);
    });
    return JSON.stringify(tourData);   
}

//var empId = 1;
//var empLevel = 'N1';
var IsDirectTourRequest = false;
var apiBaseUrl = "https://uat.tourservices.cetpainfotech.com"
function callme(e) {
    debugger;
    var dlist = document.getElementById('approvres');

    alert(e);
}
function btnTourPlanSubmit_Click(e) {
    //alert('Working Post');
    
    /// Write Code to Post Tour Plan
    if (!IsDirectTourRequest) {
        const formDataNew = new FormData();
        formDataNew.append('EmpId', empObject.empId);
        formDataNew.append('PurposeOfTour', $("#inputPurposeOfTravel").val());        
        formDataNew.append('TypeOfTour', 'Domestic');
        formDataNew.append('Destination', $("#inputDestination").val());
        formDataNew.append('Source', $("#inputSource").val());
        formDataNew.append('TantetiveDateOfDeparture', $("#inputTentativeDateOfDeparture").val());
        formDataNew.append('NoOfDays', $("#inputNumberOfDays").val());
        //formDataNew.append('IsRoad', document.getElementById('inputModeOfTravelRoad').checked);
        //formDataNew.append('IsRail', document.getElementById('inputModeOfTravelRail').checked);
        //formDataNew.append('IsAir', document.getElementById('inputModeOfTravelAir').checked);
        formDataNew.append('ClassOfCity', 'A');
        formDataNew.append('Grade', empObject.empGrade);
        if (document.getElementById('radioAdvanceRequiredYes').checked) {
            formDataNew.append('TravelEstimateAmount', $("#inputTravelEstimate").val());
            formDataNew.append('AccomodationEstimate', $("#inputAccommodationEstimate").val());
            formDataNew.append('AdvanceRequired', $("#inputAdvanceRequired").val());
            //formDataNew.append('IsX', document.getElementById('checkX').checked);
            //formDataNew.append('IsY', document.getElementById('checkY').checked);
            //formDataNew.append('IsZ', document.getElementById('checkZ').checked);
            formDataNew.append('IsAdvanceRequired', true);
            
        }
        else {
            formDataNew.append('IsAdvanceRequired', false);
        }
        //formDataNew.append('ApprovedBy', '');
        formDataNew.append('PaidAmount', 0);
        formDataNew.append('PaymentReferenceNo', 0);
        formDataNew.append('IsDirectClaim', false);
        formDataNew.append('DateOfLiquidation', (new Date()).toJSON());
        
        for (var e of uploadDetails.TourEstimate) {
            formDataNew.append('TourTravelEstimate.TravelFiles', e.uploadedFile);
        }

        formDataNew.append('TourTravelEstimate.EstimatedAmount', parseInt($("#inputTravelEstimate").val()));
        

        for (var e of uploadDetails.AccommodationEstimate) {
            formDataNew.append('TourAccommodationEstimate.AccommodationFiles', e.uploadedFile);
        }
        formDataNew.append('TourAccommodationEstimate.EstimatedAmount', parseInt($("#inputAccommodationEstimate").val()));
        debugger;
        var tPlan = createPostdataTourPlan();
        formDataNew.append('TentativeTravelPlans', tPlan);
        formDataNew.append('ManagerId', parseInt(empIdFromOrganization));
        
        
        var _url = apiBaseUrl + "​/api/TourPlan/TourRequest";
        _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

        $.ajax({
            type: "POST",
            url: _url,
            data: formDataNew,
            processData: false,
            contentType: false,
            beforeSend: function () {
                $('.page-loader').show();
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
            },
            success: function (response) {

                if (response.statusCode == 201) {
                    swal({
                        title: 'Sucess !',
                        text: 'Tour request has been successfully submitted!',
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
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            },
            error: function (jqXHR, status) {
                $('.page-loader').hide();
                $("#btnTourPlanSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
                swal({
                    title: 'Invalid !',
                    text: jqXHR.responseJSON.message,
                    type: 'error'
                });

            }
        });
    }
}
var managerIdFromOrganization = 0;
var managerCodeFromOrganization = 0;
var empIdFromOrganization = 0;
var empCodeFromOrganization = 0;
$(document).ready(function () {
    empObject= setEmpObjectFromSessionStorage();
    loadTourRequestedList();
    getEmployeeListFromOrganization();
    $("#input-datalist").change(function () {
        var el = $("#input-datalist")[0];  //used [0] is to get HTML DOM not jquery Object
        var dl = $("#approvres")[0];
        if (el.value.trim() != '') {
            var opSelected = dl.querySelector(`[value="${el.value}"]`);
            managerIdFromOrganization = opSelected.getAttribute('data-managerId');
            managerCodeFromOrganization = opSelected.getAttribute('data-managerCode');
            empIdFromOrganization = opSelected.getAttribute('data-empId');
            empCodeFromOrganization = opSelected.getAttribute('data-empCode');
        }
    });

});