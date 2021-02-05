// Query selectors
const mainMenu = document.querySelector('.main-menu');
const mainMenuToggle = document.querySelector('#main-menu-toggle');



// Toggle mobile menu + change WAI-ARIA
$('#main-menu-toggle').click(function () {
    $('.main-menu').toggle(100);

    if (mainMenu.getAttribute('aria-hidden') == 'false') {
        mainMenu.setAttribute('aria-hidden', 'true');
        mainMenuToggle.setAttribute('aria-expanded', 'false');
    } else {
        mainMenu.setAttribute('aria-hidden', 'false');
        mainMenuToggle.setAttribute('aria-expanded', 'true');
    }
});



// // Correct WAI-ARIA on resize
window.onresize = () => {
    if (window.innerWidth <= 620) {
        mainMenu.style.display = 'none';
        mainMenu.setAttribute('aria-hidden', 'true');
        mainMenuToggle.setAttribute('aria-hidden', 'false');
        mainMenuToggle.setAttribute('aria-expanded', 'false');
    } else {
        mainMenu.setAttribute('aria-hidden', 'false');
        mainMenuToggle.setAttribute('aria-hidden', 'true');
        mainMenuToggle.setAttribute('aria-expanded', 'true');
    }
}
