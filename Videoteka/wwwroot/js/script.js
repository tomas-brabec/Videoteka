function inputChange(i) {
    let hiddenInput = document.getElementById("Rating");
    let label = document.getElementById("labelRating");
    hiddenInput.value = i;
    label.innerText = `Hodnocení: ${i}/5`;
}