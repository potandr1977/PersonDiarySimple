export class CommonUtils {
    static correctDate2UTC(date) {
        if (typeof date === "string") date = new Date(date);
        return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()));
    }
    static formatDate(date) {
        var utcdate = CommonUtils.correctDate2UTC(date);
        var monthNames = [
            "January", "February", "March",
            "April", "May", "June", "July",
            "August", "September", "October",
            "November", "December"
        ];
        var day = utcdate.getDate();
        var monthIndex = utcdate.getMonth();
        var year = utcdate.getFullYear();
        return day + ' ' + monthNames[monthIndex] + ' ' + year;
    }
    
}