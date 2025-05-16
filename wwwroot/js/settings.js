document.addEventListener('DOMContentLoaded', function() {
    // Inicializar el estado del tema según localStorage
    initThemeSettings();
    
    // Inicializar selección de color
    initColorSettings();
    
    // Manejar el cambio de tema
    document.getElementById('saveAppearance').addEventListener('click', function() {
        saveAppearanceSettings();
    });
});

function initThemeSettings() {
    const savedTheme = localStorage.getItem('theme');
    
    if (savedTheme === 'dark') {
        document.getElementById('themeDark').checked = true;
    } else if (savedTheme === 'auto') {
        document.getElementById('themeAuto').checked = true;
    } else {
        document.getElementById('themeLight').checked = true;
    }
}

function initColorSettings() {
    const savedColor = localStorage.getItem('primaryColor') || 'blue';
    const colorOptions = document.querySelectorAll('.color-option');
    
    // Marcar el color guardado como seleccionado
    colorOptions.forEach(option => {
        if (option.dataset.color === savedColor) {
            option.classList.add('selected');
        }
        
        // Agregar event listener para seleccionar color
        option.addEventListener('click', function() {
            // Quitar selección anterior
            colorOptions.forEach(opt => opt.classList.remove('selected'));
            
            // Agregar selección al color actual
            this.classList.add('selected');
        });
    });
    
    // Aplicar el color guardado al documento
    document.documentElement.classList.remove('color-blue', 'color-green', 'color-red', 'color-orange', 'color-purple');
    document.documentElement.classList.add('color-' + savedColor);
}

function saveAppearanceSettings() {
    // Guardar tema
    let selectedTheme = document.querySelector('input[name="theme"]:checked').value;
    localStorage.setItem('theme', selectedTheme);
    
    // Aplicar tema
    if (selectedTheme === 'light') {
        document.documentElement.setAttribute('data-bs-theme', 'light');
        document.getElementById('theme-icon').classList.replace('bi-sun-fill', 'bi-moon-fill');
    } else if (selectedTheme === 'dark') {
        document.documentElement.setAttribute('data-bs-theme', 'dark');
        document.getElementById('theme-icon').classList.replace('bi-moon-fill', 'bi-sun-fill');
    } else {
        // Auto - usar preferencia del sistema
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        document.documentElement.setAttribute('data-bs-theme', prefersDark ? 'dark' : 'light');
        
        if (prefersDark) {
            document.getElementById('theme-icon').classList.replace('bi-moon-fill', 'bi-sun-fill');
        } else {
            document.getElementById('theme-icon').classList.replace('bi-sun-fill', 'bi-moon-fill');
        }
    }
    
    // Guardar color primario
    const selectedColorOption = document.querySelector('.color-option.selected');
    if (selectedColorOption) {
        const selectedColor = selectedColorOption.dataset.color;
        localStorage.setItem('primaryColor', selectedColor);
        
        // Aplicar color
        document.documentElement.classList.remove('color-blue', 'color-green', 'color-red', 'color-orange', 'color-purple');
        document.documentElement.classList.add('color-' + selectedColor);
    }
    
    // Mostrar mensaje de éxito
    showSuccessMessage('Preferencias de apariencia guardadas correctamente.');
}

function showSuccessMessage(message) {
    const alertHtml = `
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <i class="bi bi-check-circle me-2"></i>${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    
    // Insertar alerta al principio del contenedor
    const container = document.querySelector('.container.py-4');
    if (container) {
        // Eliminar alertas anteriores
        const existingAlerts = container.querySelectorAll('.alert');
        existingAlerts.forEach(alert => alert.remove());
        
        // Insertar nueva alerta después del encabezado
        const header = container.querySelector('.row.mb-4');
        if (header) {
            header.insertAdjacentHTML('afterend', alertHtml);
        } else {
            container.insertAdjacentHTML('afterbegin', alertHtml);
        }
    }
}
