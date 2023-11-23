//Global Declartion
var radioEmployeeSpecialDiseaseYes = document.getElementById('radioEmployeeSpecialDiseaseYes');
var radioEmployeeSpecialDiseaseNo = document.getElementById('radioEmployeeSpecialDiseaseNo');
var radioEmployeeTaxableYes = document.getElementById('radioEmployeeTaxableYes');
var radioEmployeeTaxableNo = document.getElementById('radioEmployeeTaxableNo');
var radioDoctorSpecialDiseaseYes = document.getElementById('radioDoctorSpecialDiseaseYes');
var radioDoctorSpecialDiseaseNo = document.getElementById('radioDoctorSpecialDiseaseNo');
var radioDoctorTaxableYes = document.getElementById('radioDoctorTaxableYes');
var radioDoctorTaxableNo = document.getElementById('radioDoctorTaxableNo');
var checkboxConfirmation = document.getElementById('checkboxConfirmation');


//Events
$(document).ready(function () {
    BindTableDoctorReviewClaim();
    setClaimAdvanceDefaultValue();
});
//Functions
function setClaimAdvanceDefaultValue() {
    radioEmployeeSpecialDiseaseYes.value = '';
    radioEmployeeSpecialDiseaseNo.value = '';
    radioEmployeeTaxableYes.value = '';
    radioEmployeeTaxableNo.value = '';
    radioDoctorSpecialDiseaseYes.value = '';
    radioDoctorSpecialDiseaseNo.value = '';
    radioDoctorTaxableYes.value = '';
    radioDoctorTaxableNo.value = '';
    checkboxConfirmation.value = '';
}

// ApiCallFunctions
var doctroId = 5;
// Bind Doctor Claim Review List
function BindTableDoctorReviewClaim() {
    var tblDoctorReview = $('#tbodyDoctorClaimReviewList');
    var url = apiBaseUrl + "/api/Claim/GetDoctorsClaimList/" + doctroId.toString() + "";

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

            debugger;
            console.log(response)
            console.log(response.data)
            tblDoctorReview.empty();
            var count = 1;
            $.each(response.data, function () {
                var rowDoctorReview = ` <tr>
                            <td>${count}</td>
                              
                            <td>
                                ${this.employeeName}                                
                            </td>

                            <td>
                                ${this.patientName}
                            
                            </td>
                            <td>
                                    ${this.relation}
                                    
                            </td>
                           
                            <td>
                                 ${this.requetDate}
                                 
                            </td>
                            <td>
                               <button class="btn btn-success-details" type="button" onclick="doctorReview_app(${this.empId},'${this.employeeName}','${this.patientName}','${this.requestDate}','${this.approvedAmount}','${this.advanceId}')">Details</button>
                               </td>
                        </tr>`;
                tblDoctorReview.append(rowDoctorReview);

                count++;
            });
            $('.page-loader').hide();
        },
        failure: function (response) {
            $('.page-loader').hide();
            // alert(response.d);
        }
    });
}

var doctorReview_List = document.getElementById("doctorReview_List");
function doctorReview_app(emp_id, emp_name, emp_relation, emp_date, emp_amt, advanceId) {
    //getformdetailes(advanceId);
    doctorReview_List.style.display = "block";

}





