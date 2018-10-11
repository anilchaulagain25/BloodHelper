jQuery.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).removeClass("is-valid").addClass("is-invalid");
        } else {
            $(element).removeClass("is-valid").addClass("is-invalid");
        } 
    },
    unhighlight: function (element, errorClass, validClass) {
       
        if (element.type === 'radio') {
            this.findByName(element.name).addClass("is-valid").removeClass("is-invalid");
        } else {
            $(element).addClass("is-valid").removeClass("is-invalid");
        }
    }
});