window.diarioCharts = {

    // Método para desenhar o gráfico de barras/pizza
    renderizarGraficoEmocoes: function (canvasId, labels, dataCounts) {

        console.log("Função JS chamada com sucesso!");
        console.log("Labels recebidas:", labels);
        console.log("Dados recebidos:", dataCounts);
        alert('teste de mensagem');

        const ctx = document.getElementById(canvasId).getContext('2d');

        // Configuração básica do Chart.js
        new Chart(ctx, {
            type: 'bar', // Tipo de gráfico: Barras
            data: {
                labels: labels, // Nomes das Emoções (ex: "Ansiedade", "Alegria")
                datasets: [{
                    label: 'Frequência de Emoções',
                    data: dataCounts, // Contagem de cada emoção
                    backgroundColor: [
                        // Uma lista de cores para o gráfico
                        'rgba(255, 99, 132, 0.6)',  // Vermelho
                        'rgba(54, 162, 235, 0.6)',  // Azul
                        'rgba(255, 206, 86, 0.6)',  // Amarelo
                        'rgba(75, 192, 192, 0.6)',  // Verde
                        'rgba(153, 102, 255, 0.6)', // Roxo
                        'rgba(255, 159, 64, 0.6)'   // Laranja
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false, // Permite que o gráfico use o tamanho do container
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }
};