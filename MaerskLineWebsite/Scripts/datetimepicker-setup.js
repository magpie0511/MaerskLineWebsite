$('.datetimepicker').datetimepicker({
    pickDate: true,                 //en/disables the date picker
    pickTime: true,                 //en/disables the time picker
    useMinutes: false,              //en/disables the minutes picker
    useSeconds: false,              //en/disables the seconds picker
    startDate: moment().subtract('days', 1)// a minimum date
});