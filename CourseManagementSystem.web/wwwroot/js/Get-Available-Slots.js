$(document).ready(function () {
    $("#CourseId").change(function (e) {
        e.preventDefault();
        var courseId = $(this).val();
        if (courseId) {
            $.ajax({
                url: "/Enrollment/GetAvailableSlots",
                type: "GET",
                data: { courseId: courseId },
                success: function (response) {
                    $("#availableSlots").text(response.availableSlots);
                    if (response.availableSlots === 0) {
                        toastr.warning("No available slots in this course.");
                        $("button[type='submit']").prop("disabled", true);
                    } else {
                        $("button[type='submit']").prop("disabled", false);
                    }
                }
            });
        }
    });
});
