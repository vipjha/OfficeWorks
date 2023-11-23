var empObject = { empId: 0, empCode: 0, empGrade: '', empDesignation: '', empUnit: '', Name: '', Role: '', EmailId: '', Mobile: '' };
function setEmpObjectFromSessionStorage() {
    
    empObject.empId = localStorage.getItem('empId');
    empObject.empCode = localStorage.getItem('empCode');
    empObject.empGrade = localStorage.getItem('empGrade');
    empObject.empDesignation = localStorage.getItem('empDesignation');
    //empObject.empDepartment = sessionStorage.getItem('empDepartment');
    empObject.empUnit = localStorage.getItem('empUnit');
    empObject.Name = localStorage.getItem('Name');
    empObject.Role = localStorage.getItem('Role');
    empObject.EmailId = localStorage.getItem('EmailId');
    empObject.Mobile = localStorage.getItem('Mobile');
    return empObject;
}
function CalculateDAArray(startDate, startTime, endDate, endTime, gradeWiseDAAmount = 1250) {
    function getTimeDiffrence(startDate, startTime, endDate, endTime) {
        var startDuration = Date.parse(startDate) + Date.parse(new Date('1970-01-01T' + startTime + 'Z'));
        var endDuration = Date.parse(endDate) + Date.parse(new Date('1970-01-01T' + endTime + 'Z'));
        var timeDiffrence = endDuration - startDuration;
        var minutes = 1000 * 60;
        var hour = minutes * 60;
        var day = hour * 24;
        var totalTimeInMinutes = timeDiffrence / minutes;
        var TotalDaysInTime = parseInt(totalTimeInMinutes / (60 * 24));
        var RemainingMinutesAfterDaysCalculation = totalTimeInMinutes % (60 * 24);
        var TotalHoursInTime = parseInt(RemainingMinutesAfterDaysCalculation / 60);
        var totalMinutesAfterHoursCalculations = RemainingMinutesAfterDaysCalculation % 60;
        var timeDiffrence = { Days: TotalDaysInTime, Hours: TotalHoursInTime, Minutes: totalMinutesAfterHoursCalculations };
        return timeDiffrence;
    }

    function getDAPercentageBYHours(Hours, Minutes) {
        if (Hours <= 6) {
            if (Hours == 6 && Minutes > 0)
                return 70;
            return 30;
        }
        else if (Hours <= 12) {
            if (Hours == 12 && Minutes > 0)
                return 100;
            return 70;
        }
        else {
            return 100;
        }
    }
    var arrDA = [];
    startDate = new Date(startDate);
    endDate = new Date(endDate);
    if (startDate.toString() === endDate.toString()) {
        var diff = getTimeDiffrence(startDate, startTime, endDate, endTime);
        var DAPercentage = getDAPercentageBYHours(diff.Hours, diff.Minutes);
        var daObject = { startDate: new Date(startDate), startTime: startTime, endDate: new Date(endDate), endTime: endTime, Hours: diff.Hours, Minutes: diff.Minutes, DAPercentage: DAPercentage, DAAmount: gradeWiseDAAmount, DAOfTheDay: gradeWiseDAAmount * (DAPercentage / 100) };
        arrDA.push(daObject);
        return arrDA;
    }
    else {
        var diff = getTimeDiffrence(startDate, startTime, startDate, '24:00');
        var DAPercentage = getDAPercentageBYHours(diff.Hours, diff.Minutes);
        var daObject = { startDate: new Date(startDate), startTime: startTime, endDate: new Date(startDate), endTime: '23:59', Hours: diff.Hours, Minutes: diff.Minutes, DAPercentage: DAPercentage, DAAmount: gradeWiseDAAmount, DAOfTheDay: gradeWiseDAAmount * (DAPercentage / 100) };
        arrDA.push(daObject);
        startDate.setDate(startDate.getDate() + 1);
        while (startDate < endDate) {
            var DAPercentage = getDAPercentageBYHours(24, 0);
            var daObject = { startDate: new Date(startDate), startTime: '00:00', endDate: new Date(startDate), endTime: '23:59', Hours: 24, Minutes: 0, DAPercentage: DAPercentage, DAAmount: gradeWiseDAAmount, DAOfTheDay: gradeWiseDAAmount * (DAPercentage / 100) };
            arrDA.push(daObject);
            startDate.setDate(startDate.getDate() + 1);
        }
        var diff = getTimeDiffrence(startDate, '00:00', startDate, endTime);
        var DAPercentage = getDAPercentageBYHours(diff.Hours, diff.Minutes);
        var daObject = { startDate: new Date(startDate), startTime: '00:00', endDate: new Date(endDate), endTime: endTime, Hours: diff.Hours, Minutes: diff.Minutes, DAPercentage: DAPercentage, DAAmount: gradeWiseDAAmount, DAOfTheDay: gradeWiseDAAmount * (DAPercentage / 100) };
        arrDA.push(daObject);
    }
    return arrDA;

}
