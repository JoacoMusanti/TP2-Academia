$(document).ready(function () {


    $('input[name="selected"]').click(function () {

        $('input[type="radio"]:checked').each(function () {
            var edit = $('input[name="hdnController"]').val() + '/Edit';
            var del = $('input[name="hdnController"]').val() + '/Delete';
            var id1 = ($(this).attr('id'));

            $('a[name=lnkEdit]').prop("href", edit + "/" + id1);
            $('a[name=lnkDelete]').prop("href", del + "/" + id1);
        });
    });

});