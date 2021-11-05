function load(string) {
	document.getElementById('hide').style.display = 'none';
	document.getElementById('addPage').style.display = 'inline';
	var parser, xmlDoc;
	parser = new DOMParser();
	xmlDoc = parser.parseFromString(string,"text/xml");		
	for (let i = 0; i < Number.MAX_VALUE; i++) {
		document.getElementById("table").innerHTML = document.getElementById("table").innerHTML + "<div><tr><td class='name'>" + xmlDoc.getElementsByTagName("name")[i].childNodes[0].nodeValue + "</td><td class='price'>" + xmlDoc.getElementsByTagName("price")[i].childNodes[0].nodeValue + "</td></tr></div>";
	}
}

function add() {
	var _1 = document.getElementById('nameAdd');
	var _2 = document.getElementById('priceAdd');
    var name = _1.value;
	var price = Number(_2.value);
	if (name.length > 0 && !isNaN(price)) {
		text = text.substring(text.length - 9, 8);
		text = text + "<item id='12'><name>" + name + "</name><price>" + price + "</price></item></drinks>";
		console.log(text);
		document.getElementById('nameAdd').value = "";
		document.getElementById('priceAdd').value = "";
		document.getElementById('addPage').style.display = 'inline';
		document.getElementById("h1").innerHTML = "Aktuális itallap:";
		document.getElementById('nameAdd').style.display = 'none';
		document.getElementById('priceAdd').style.display = 'none';
		document.getElementById('add').style.display = 'none';
		load(text);
	}
	else
	{	
		alert("Tölts ki minden mezőt helyesen!");
	}
}

function openAdd() {
	document.getElementById('table').innerHTML = "";
	document.getElementById('hide').style.display = 'none';
	document.getElementById('addPage').style.display = 'none';
	document.getElementById("h1").innerHTML = "Tétel hozzáadás:";
	document.getElementById('nameAdd').style.display = 'inline';
	document.getElementById('priceAdd').style.display = 'inline';
	document.getElementById('add').style.display = 'inline';
}

var text = "<drinks>" + 
"<item id='1'>" + 
"<name>Heineken</name>" + 
"<price>450</price>" + 
"</item>" + 
"<item id='2'>" + 
"<name>RedBull</name>" + 
"<price>500</price>" + 
"</item>" + 
"<item id='3'>" + 
"<name>Korsó Soproni</name>" + 
"<price>350</price>" + 
"</item>" + 
"<item id='4'>" + 
"<name>Tátratea 72</name>" + 
"<price>900</price>" + 
"</item>" + 
"<item id='5'>" + 
"<name>Tátratea 62</name>" + 
"<price>900</price>" + 
"</item>" + 
"<item id='6'>" + 
"<name>Tátratea 52</name>" + 
"<price>900</price>" + 
"</item>" + 
"<item id='7'>" + 
"<name>Víz</name>" + 
"<price>250</price>" + 
"</item>" + 
"<item id='8'>" + 
"<name>CocaCola</name>" + 
"<price>350</price>" + 
"</item>" + 
"<item id='9'>" + 
"<name>Fanta</name>" + 
"<price>350</price>" + 
"</item>" + 
"<item id='10'>" + 
"<name>Kinley</name>" + 
"<price>350</price>" + 
"</item>" + 
"<item id='11'>" + 
"<name>Nachos</name>" + 
"<price>600</price>" + 
"</item>" + 
"</drinks>";