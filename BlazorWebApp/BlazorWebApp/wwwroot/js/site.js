function toggleMobileMenu() {
    var menu = document.getElementById('mobile-menu');
    if (menu.classList.contains('show')) {
        menu.classList.remove('show');
    } else {
        menu.classList.add('show');
    }
}

function closeMobileMenuOnResize() {
    var menu = document.getElementById('mobile-menu');
    if (menu.classList.contains('show')) {
        menu.classList.remove('show');
    }
}

window.addEventListener('resize', closeMobileMenuOnResize);