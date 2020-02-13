var global;

$(document).ready(function () {
	$("#btnSubmit").trigger("click");
});

$("body").on("click", ".imgEditContact", function () {
	global = $(this);
	imageSave($(this), "imgSaveContact");
});

$("body").on("click", ".imgEditCompany", function () {
	global = $(this);
	imageSave($(this), "imgSaveCompany");
});

$("body").on("click", ".imgEditWoisCount", function () {
	global = $(this);
	imageSave($(this), "imgSaveWoisCount");
});

$("body").on("click", ".imgEditWoisDate", function () {
	global = $(this);
	editField = $(this).closest("tr").find("p")[0];
	var text = editField.innerHTML;

	var from = text.split(".");
	var newDate = from[2] + "-" + from[1] + "-" + from[0];

	$(this).attr("src", "/Fenix/Content/img/save.png");
	$(this).attr("class", "imgSaveWoisDate");
	editField.innerHTML = '<input id="editable" type="date" value="' + newDate + '"/><input id="oldValue" value="' + text + '" hidden />';
	$("#editable").attr("max", new Date().toISOString().split("T")[0]);
	$("#editable").focus();
});

$("#btnCancel").click(function () {
	$("#addEventModal").modal("show");
});

function imageSave(self, newClass) {
    editField = self.closest("tr").find("p")[0];
    var text = editField.innerHTML;
    self.attr("src", "/Fenix/Content/img/save.png");
    self.attr("class", newClass);
    editField.innerHTML = '<input id="editable" type="text" value="' + text + '"/><input id="oldValue" value="' + text + '" hidden />';
    $("#editable").focus();
}

function imageEdit(self, newClass) {
    self.attr("src", "/Fenix/Content/img/edit.png");
    self.attr("class", newClass);
}

function saveChanges(self, URL, data, newClass) {
    var editField = self.closest("tr").find("p")[0];
    var text = self.closest("tr").find("input").val();
	$.ajax({
		url: URL,
		data: data,
		success: function (result) {
			if (result) {
				imageEdit(self, newClass);
				text = text.replace("<", "&lt").replace(">", "&gt");
				editField.innerHTML = text;
			}
			else {
				alert("Something went wrong");
			}
		}
	});
}

$("body").on("focusout", "#editable", function () {
	if (!global.is(":hover")) {
		if ($(this).val() == $("#oldValue").val()) {
			$(this).closest("td").find("p")[0].innerHTML = $("#oldValue").val();
		}
		else {
			if (confirm('Сохранить изменения?')) {
				global.trigger("click");
			} else {
				$(this).closest("td").find("p")[0].innerHTML = $("#oldValue").val();
			}
		}
		var newClass = global.attr("class");
		imageEdit(global, "imgEdit" + newClass.substring(7));
		$("#oldValue").remove();
	}
});

$("#btnConfirm").click(function () {
	var self = $(this);
	$.ajax({
		url: self.data('request-url'),
		type: "POST",
		data: { eventName: $("#inputHiddenEventName").val() },
		success: function (result) {
			if (!result)
				alert("Something went wrong");
		}
	});
});

$("body").on("change", ".eventCheckbox", function () {
	var self = $(this);
	var $idAPAF = self.closest("tr").find("td")[0].innerHTML;
	var $eventId = self.attr('id');
	var $value = self.prop('checked');

	$.ajax({
		url: self.data('request-url'),
		data:
		{
			idAPAF: $idAPAF,
			eventId: $eventId,
			value: $value
		},
		type: "POST",
		success: function (result) {
			if (result)
				self.closest("td").css("background-color", "green");
			else
				self.closest("td").css("background-color", "red");
		},
		error: function () {
			self.closest("td").css("background-color", "red");
		}
	})
});

$("body").on("change", ".checkboxUnsubscribe", function () {
	var self = $(this);
	var $idAPAF = self.closest("tr").find("td")[0].innerHTML;
	var $value = self.prop('checked');

	$.ajax({
		url: self.data('request-url'),
		data:
		{
			idAPAF: $idAPAF,
			value: $value
		},
		success: function (result) {
			if (result)
				self.closest("td").css("background-color", "green");
			else
				self.closest("td").css("background-color", "red");
		},
		error: function () {
			self.closest("td").css("background-color", "red");
		}
	})
});

$("#SelectedEvents").change(function () {
	$("#SelectedEvents > option").each(function () {
		var name = "Event=" + this.value;
		if (this.selected) {
			if (!$("#dtResult").DataTable().column(name + ":name").visible())
				$("#dtResult").DataTable().column(name + ":name").visible(true);
		}
		else {
			if ($("#dtResult").DataTable().column(name + ":name").visible())
				$("#dtResult").DataTable().column(name + ":name").visible(false);
		}
	});
});

$("#btnCopy").click(function () {
	$("#blackDivForFullScreen").show();
	var self = $(this);
	$.ajax({
		url: self.data('request-url'),
		type: "POST",
		data:
		{
			copyFrom: $("#ddCopyFrom").val(),
			copyTo: $("#ddCopyTo").val()
		},
		success: function (result) {
			if (result)
				$("#btnSubmit").trigger("click");
		},
		error: function () {
			alert("Something went wrong");
		}
	});
});

$("#btnAdd").click(function () {
	var self = $(this);
	$.ajax({
		url: self.data('request-url'),
		type: "POST",
		data: { eventType: $("#selectAddEvent").val() },
		success: function (result) {
			$("#confirmAddEventModal").modal("show");
			$("#confirmAddEventModalBody").html("<b>Event '" + result + "' will be added. Are you sure?</b><input id='inputHiddenEventName' type='text' value='" + result + "' hidden />");
		}
	});
});

$("body").on("click", ".viewCase", function () {
	var FirmId = $(this).attr("id");
	$.ajax({
		url: '/Fenix/AllPAFirmModal/FirmCaseInfoModal',
		data: {
			firmId: FirmId
		},
		type: "GET",
		success: function (output) {
			$("#dialogContent").html(output);
			$("#modDialog").modal("toggle");
		}
	});
});