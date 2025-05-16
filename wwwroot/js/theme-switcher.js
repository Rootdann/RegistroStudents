// Theme switcher functionality
document.addEventListener('DOMContentLoaded', function() {
    // Obtener el botón de cambio de tema
    const themeToggle = document.getElementById('theme-toggle');
    const themeIcon = document.getElementById('theme-icon');
    
    // Inicializar tema y color
    initializeThemeAndColor();
    
    // Manejar el cambio de tema
    themeToggle.addEventListener('click', function() {
        const currentTheme = document.documentElement.getAttribute('data-bs-theme');
        
        if (currentTheme === 'light') {
            document.documentElement.setAttribute('data-bs-theme', 'dark');
            localStorage.setItem('theme', 'dark');
            themeIcon.classList.replace('bi-moon-fill', 'bi-sun-fill');
        } else {
            document.documentElement.setAttribute('data-bs-theme', 'light');
            localStorage.setItem('theme', 'light');
            themeIcon.classList.replace('bi-sun-fill', 'bi-moon-fill');
        }
    });
});

function initializeThemeAndColor() {
    const themeIcon = document.getElementById('theme-icon');
    
    // Verificar si hay un tema guardado en localStorage
    const savedTheme = localStorage.getItem('theme') || 'light';
    
    // Aplicar el tema guardado
    if (savedTheme === 'dark') {
        document.documentElement.setAttribute('data-bs-theme', 'dark');
        if (themeIcon) themeIcon.classList.replace('bi-moon-fill', 'bi-sun-fill');
    } else if (savedTheme === 'auto') {
        // Auto - usar preferencia del sistema
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        document.documentElement.setAttribute('data-bs-theme', prefersDark ? 'dark' : 'light');
        
        if (themeIcon) {
            if (prefersDark) {
                themeIcon.classList.replace('bi-moon-fill', 'bi-sun-fill');
            } else {
                themeIcon.classList.replace('bi-sun-fill', 'bi-moon-fill');
            }
        }
    } else {
        document.documentElement.setAttribute('data-bs-theme', 'light');
        if (themeIcon) themeIcon.classList.replace('bi-sun-fill', 'bi-moon-fill');
    }
    
    // Aplicar color primario guardado
    const savedColor = localStorage.getItem('primaryColor') || 'blue';
    document.documentElement.classList.remove('color-blue', 'color-green', 'color-red', 'color-orange', 'color-purple');
    document.documentElement.classList.add('color-' + savedColor);
}
