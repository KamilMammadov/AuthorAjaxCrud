



console.log("salam")

const cookieObj = new URLSearchParams(document.cookie.replaceAll("&", "%26").replaceAll("; ", "&"))
var color = cookieObj.get("SiteColors")
console.log(color)

let obj = JSON.parse(color);
 
document.body.style.backgroundColor = obj.Name

//const uri = '%7B%22Id%22%3A3%2C%22Name%22%3A%22green%22%7D';
//const encoded = encodeURI(uri);
//console.log(encoded);
//// expected output: "https://mozilla.org/?x=%D1%88%D0%B5%D0%BB%D0%BB%D1%8B"

//try {
//    console.log(decodeURI(encoded));
//    // expected output: "https://mozilla.org/?x=шеллы"
//} catch (e) { // catches a malformed URI
//    console.error(e);
//}


//Id"%3A1%2C"Name"%3A"black




