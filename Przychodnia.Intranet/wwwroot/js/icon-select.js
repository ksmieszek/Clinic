var iconSelect;

window.onload = function () {

    iconSelect = new IconSelect("my-icon-select");

    var icons = [];
    icons.push({ 'iconFilePath': '../img/p1.jpg', 'iconValue': 'p1.jpg' });
    icons.push({ 'iconFilePath': '../img/p2.jpg', 'iconValue': 'p2.jpg' });
    icons.push({ 'iconFilePath': '../img/p3.jpg', 'iconValue': 'p3.jpg' });
    icons.push({ 'iconFilePath': '../img/p4.jpg', 'iconValue': 'p4.jpg' });

    iconSelect.refresh(icons);
};