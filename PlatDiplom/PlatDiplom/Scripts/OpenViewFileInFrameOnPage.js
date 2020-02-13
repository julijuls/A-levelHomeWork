function openViewFile(typeFile, fileLink) {
    var fullLinkToFile = "";
    console.log(typeFile);
    console.log(fileLink);
    typeFile = typeFile.toLowerCase();
    switch (typeFile) {
        case "docx":
        case ".docx":
        case ".doc":
        case "xlsx":
        case ".xlsx":
        case ".xls":
        case ".ppt":
        case "pptx":
        case ".pptx":
            fullLinkToFile = "<iframe "
            fullLinkToFile = fullLinkToFile + "src='https://view.officeapps.live.com/op/embed.aspx?";
            fullLinkToFile = fullLinkToFile + "src=https://vision.mspcorporate.com/";
            fullLinkToFile = fullLinkToFile + fileLink;
            fullLinkToFile = fullLinkToFile + "&wdStartOn=1'";
            fullLinkToFile = fullLinkToFile + " height='100%' width='100%' frameborder='0'></iframe>";
            break;
        case ".pdf":
        case ".jpg":
        case ".txt":
        case ".png":
        case "jpeg":
        case ".gif":
        case ".bmp":
        case ".tif":
            fullLinkToFile = "<iframe "
            fullLinkToFile = fullLinkToFile + "src='" + fileLink + "'";
            fullLinkToFile = fullLinkToFile + " height='100%' width='100%' frameborder='0'></iframe>";
            break;
        default:
            fullLinkToFile = "Undefined format File";
    }

    return fullLinkToFile;
}



function CreateModalWindowForFileView(extension, path) {
    var requestFileContent = $('<div>').attr({
        class: "modal-content"
    }).append($('<div>').attr({
        class: "modal-header"
    }).append($('<button>').attr({
        class: "close",
        'data-dismiss': "modal",
        'area-hidden': "true"
    }).append(' X ')).append($('<h4>').append('View File'))).append($('<div>').attr({
        class: "modal-body"
    }).append(openViewFile(extension, path)));
    $('#dialogContent').html(requestFileContent).show(1000);
    $('#modDialog').modal('show');
    $('#blackDivForFullScreen').hide();
}
$(document).ready(function () {
    $("body").on("click", ".viewFile", function () {
        var $this = $(this);
        console.log($this.attr('filePath'));
        CreateModalWindowForFileView($this.attr('fileExtension'), $this.attr('filePath'));
    });
});
