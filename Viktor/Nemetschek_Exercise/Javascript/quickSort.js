function partition(arr, left, right){
    let pivot = arr[right];
    let i = left - 1;
    for(let j = left; j < right; j++){
        if(arr[j] <= pivot){
            let temp = arr[j];
            arr[j] = arr[++i];
            arr[i] = temp;
        }
    }
    let temp = arr[i + 1];
    arr[i + 1] = pivot;
    arr[right] = temp;
    return i + 1;
}
function quickSort(arr, left, right){
    if(left < right){
        let pivot = partition(arr, left, right);
        quickSort(arr, left, pivot - 1); // left side
        quickSort(arr, pivot + 1, right); // right  side
    }
}
let arr = [4,6,1,5,2,3,8,7,9];
quickSort(arr, 0, arr.length - 1);
console.log(arr);