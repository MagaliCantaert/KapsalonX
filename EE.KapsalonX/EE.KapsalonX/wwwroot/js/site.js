// Initialize as global component
Vue.component('date-picker', VueBootstrapDatetimePicker);

// Using font-awesome 5 icons
$.extend(true, $.fn.datetimepicker.defaults, {
    icons: {
        time: 'far fa-clock',
        date: 'far fa-calendar',
        up: 'fas fa-arrow-up',
        down: 'fas fa-arrow-down',
        previous: 'fas fa-chevron-left',
        next: 'fas fa-chevron-right',
        today: 'fas fa-calendar-check',
        clear: 'far fa-trash-alt',
        close: 'far fa-times-circle'
    }
});

new Vue({
    el: '#app',
    data: {
        date: null,
        options: {
            // https://momentjs.com/docs/#/displaying/
            format: 'DD/MM/YYYY h:mm:ss',
            useCurrent: false,
            showClear: true,
            showClose: true,
        }
    },
});