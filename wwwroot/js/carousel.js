document.addEventListener('DOMContentLoaded', function () {
    // Your carousel JavaScript code here
    const prevButton = document.getElementById('prev');
    const nextButton = document.getElementById('next');
    const carousel = document.querySelector('.carousel');
    const cards = document.querySelectorAll('.carousel-card');
    let currentIndex = 0;

    prevButton.addEventListener('click', () => {
        if (currentIndex > 0) {
            currentIndex--;
            updateCarousel();
        }
    });

    nextButton.addEventListener('click', () => {
        if (currentIndex < cards.length - 1) {
            currentIndex++;
            updateCarousel();
        }
    });

    function updateCarousel() {
        cards.forEach((card, index) => {
            card.style.transform = `translateX(${100 * (index - currentIndex * 2)}%)`;
        });
    }

    updateCarousel();
});
