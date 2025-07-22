// JavaScript source code
function calculatePower() {
	let base = Number(document.getElementById('base').value);
	let exponent = Number(document.getElementById('exponent').value);
	document.getElementById('power').value = Power(base, exponent);
}
function Power(base, exponent) {
	return base ** exponent;
}
function SwitchBackground() {
	let switchButton = document.getElementById('switchBackground');
	//console.log(switchButton.attributes.src);
	//switchButton.attributes.src.nodeValue = switchButton.attributes.src.nodeValue == 'img/moon.png' ? 'img/sun.png' : 'img/moon.png';
	/*if (switchButton.attributes.src.nodeValue == 'img/moon.png')
	{
		switchButton.attributes.src.nodeValue = 'img/sun.png';
		document.body.style.background = "#323232";
		document.body.style.color = "white";
	}
	else
	{
		switchButton.attributes.src.nodeValue = 'img/moon.png';
		document.body.style.background = "#FFFFFF";
		document.body.style.color = "black";
	}*/
	let delay = Number(document.getElementById("delay").value);
	console.log(delay);
	document.body.style.transition = `background-color ${delay}s, color ${delay}s`;
	document.getElementById('switchBackground').style.transition = `background-image ${delay}s`;
	document.body.className = document.body.className === "light" ? "dark" : "light";
}
document.addEventListener("mousemove", function (event) {
	let x = event.clientX;
	let y = event.clientY;
	document.getElementById("mouse").innerHTML = `X = ${x}, Y = ${y}`;
}
);

function setImage() {
	let filename = document.getElementById("image-file");
	//console.log(filename);
	//let splitted_filename = filename.split('\\');
	//document.getElementById("photo").src = splitted_filename[splitted_filename.length - 1];
	let reader = new FileReader();
	reader.onload = function (e) {
		document.getElementById("photo").src = e.target.result;
	}
	reader.readAsDataURL(filename.files[0]);
}

document.body.onload = function tick_timer() {
	let time = new Date();
	document.getElementById("full-time").innerHTML = time;
	document.getElementById("hours").innerHTML = addLeadingZero(time.getHours());
	document.getElementById("minutes").innerHTML = addLeadingZero(time.getMinutes());
	document.getElementById("seconds").innerHTML = addLeadingZero(time.getSeconds());

	document.getElementById("year").innerHTML = time.getFullYear();
	document.getElementById("month").innerHTML = addLeadingZero(time.getMonth() + 1);
	document.getElementById("day").innerHTML = addLeadingZero(time.getDate());

	document.getElementById("weekday").innerHTML = time.toLocaleDateString("ru", { weekday: 'long' });

	/*if (document.getElementById("show-date").checked)
	{
		document.getElementById("current-date").style.visibility = "visible";
	}
	else
	{
		document.getElementById("current-date").style.visibility = "hidden";
	}*/

	document.getElementById("current-date").style.visibility = document.getElementById("show-date").checked ? "visible" : "hidden";
	document.getElementById("weekday").style.visibility = document.getElementById("show-weekday").checked ? "visible" : "hidden";

	setTimeout(tick_timer, 100);	//������� setTimeout(function,delay) �������� ������� 'function' � ��������� 'delay'.
}
function addLeadingZero(number) {
	return number < 10 ? "0" + number : number;
}

document.getElementById("btn-start").onclick = function startCountdownTimer() {
	let targetDate = document.getElementById("target-date");
	let targetTime = document.getElementById("target-time");
	let btnStart = document.getElementById("btn-start");
	targetDate.disabled = targetTime.disabled = !targetDate.disabled;
	if (btnStart.value === "Start") {
		btnStart.value = "Stop";
		tickCountdown();
	}
	else {
		btnStart.value = "Start";
	}
}
function tickCountdown() {
	if (!document.getElementById("target-time").disabled) return;
	let now = new Date();
	console.log(`now timezoneOffset:\t${now.getTimezoneOffset()}`);
	//Controls - ��� �������� ����������.
	let targetDateControl = document.getElementById("target-date");
	let targetTimeControl = document.getElementById("target-time");
	let targetDate = targetDateControl.valueAsDate;
	let targetTime = targetTimeControl.valueAsDate;

	//����������� ������� ����:
	targetDate.setHours(targetDate.getHours() + targetDate.getTimezoneOffset() / 60);
	targetTime.setHours(targetTime.getHours() + targetTime.getTimezoneOffset() / 60);

	//�������� ���� � ������� ������� � ��������� ����:
	targetTime.setFullYear(targetDate.getFullYear());
	targetTime.setMonth(targetDate.getMonth());
	targetTime.setDate(targetDate.getDate());

	//���������� ���������� ������� �� ��������� ����:
	let duration = targetTime - now;    //�������� ��� ����������� � ������� Timestamp
	document.getElementById("duration").innerHTML = duration;
	//Timestamp - ��� ���������� ����������� �� 1 ������ 1970.
	let timestamp = Math.trunc(duration / 1000);
	document.getElementById("timestamp").innerHTML = timestamp;

	//���������� ������� ����/����� � ���������� �� ��������:
	document.getElementById("target-date-value").innerHTML = targetDate;
	document.getElementById("target-time-value").innerHTML = targetTime;

	console.log(`targetTime timezoneOffset:\t${now.getTimezoneOffset()}`);

	const SECONDS_IN_MINUTE = 60;
	const SECOND_IN_HOUR = 3600;
	const SECOND_IN_DAY = 86400;
	const SECONDS_IN_WEEK = SECONDS_IN_DAY * 7;
	const DAYS_IN_MONTH = 365.25 / 12;
	const SECONDS_IN_MONTH = SECOND_IN_DAY * SECONDS_IN_MONTH;
	const SECONDS_IN_YEAR = SECOND_IN_DAY * 365 + SECONDS_IN_HOUR * 6;

	let time_of_day = timestamp % SECOND_IN_DAY;
	let hours = Math.floor(time_of_day / SECONDS_IN_HOUR);
	if (hours > 0) time_of_day = (time_of_day % (hours * SECOND_IN_HOUR))

	let minutes = Math.floor(time_of_day / SECONDS_IN_MINUTE);
	if (minutes > 0) time_of_day = (time_of_day % (minutes * SECONDS_IN_MINUTE));

	let seconds = time_of_day;
	/////////////////////////////////////////////////////////////////////////////////////////////////////

	document.getElementById("hours-unit").innerHTML = addLeadingZero(hours);
	document.getElementById("minutes-unit").innerHTML = addLeadingZero(minute);
	document.getElementById("seconds-unit").innerHTML = addLeadingZero(seconds);

	/////////////////////////////////////////////////////////////////////////////////////////////////////

	setTimeout(tickCountdown, 100);
}