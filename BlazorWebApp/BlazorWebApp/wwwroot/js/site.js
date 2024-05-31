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

function setDarkMode(isDark) {
    if (isDark) {
        document.body.classList.add('dark-mode');
        localStorage.setItem('isDarkMode', 'true');
    } else {
        document.body.classList.remove('dark-mode');
        localStorage.setItem('isDarkMode', 'false');
    }
}

function loadDarkModePreference() {
    const isDarkMode = localStorage.getItem('isDarkMode') === 'true';
    if (isDarkMode) {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
    }
    return isDarkMode;
}

document.addEventListener('DOMContentLoaded', (event) => {
    const isDarkMode = loadDarkModePreference();
    const switchMode = document.getElementById('switch-mode');
    if (switchMode) {
        switchMode.checked = isDarkMode;
    }
});


