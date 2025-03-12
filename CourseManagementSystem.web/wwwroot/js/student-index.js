$(document).ready(function () {
    $(".delete-student").click(function () {
        var studentId = $(this).data("id");
        if (confirm("Are you sure you want to delete this student?")) {
            $.ajax({
                url: "/Student/Delete/" + studentId,
                type: "POST",
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert("Failed to delete student.");
                }
            });
        }
    });
});