﻿$(function () {
    'use strict'
    $('.connectedSortable').sortable({ placeholder: 'sort-highlight', connectWith: '.connectedSortable', handle: '.card-header, .nav-tabs', forcePlaceholderSize: true, zIndex: 999999 })
    $('.connectedSortable .card-header').css('cursor', 'move')
    $('.todo-list').sortable({ placeholder: 'sort-highlight', handle: '.handle', forcePlaceholderSize: true, zIndex: 999999 })
    $('.textarea').summernote()
    $('.daterange').daterangepicker({ ranges: { Today: [moment(), moment()], Yesterday: [moment().subtract(1, 'days'), moment().subtract(1, 'days')], 'Last 7 Days': [moment().subtract(6, 'days'), moment()], 'Last 30 Days': [moment().subtract(29, 'days'), moment()], 'This Month': [moment().startOf('month'), moment().endOf('month')], 'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')] }, startDate: moment().subtract(29, 'days'), endDate: moment() }, function (start, end) { alert('You chose: ' + start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY')) })
    $('.knob').knob()
    var visitorsData = { US: 398, SA: 400, CA: 1000, DE: 500, FR: 760, CN: 300, AU: 700, BR: 600, IN: 800, GB: 320, RU: 3000 }
    $('#world-map').vectorMap({ map: 'usa_en', backgroundColor: 'transparent', regionStyle: { initial: { fill: 'rgba(255, 255, 255, 0.7)', 'fill-opacity': 1, stroke: 'rgba(0,0,0,.2)', 'stroke-width': 1, 'stroke-opacity': 1} }, series: { regions: [{ values: visitorsData, scale: ['#ffffff', '#0154ad'], normalizeFunction: 'polynomial'}] }, onRegionLabelShow: function (e, el, code) { if (typeof visitorsData[code] !== 'undefined') { el.html(el.html() + ': ' + visitorsData[code] + ' new visitors') } } })
    var sparkline1 = new Sparkline($('#sparkline-1')[0], { width: 80, height: 50, lineColor: '#92c1dc', endColor: '#ebf4f9' })
    var sparkline2 = new Sparkline($('#sparkline-2')[0], { width: 80, height: 50, lineColor: '#92c1dc', endColor: '#ebf4f9' })
    var sparkline3 = new Sparkline($('#sparkline-3')[0], { width: 80, height: 50, lineColor: '#92c1dc', endColor: '#ebf4f9' })
    sparkline1.draw([1000, 1200, 920, 927, 931, 1027, 819, 930, 1021])
    sparkline2.draw([515, 519, 520, 522, 652, 810, 370, 627, 319, 630, 921])
    sparkline3.draw([15, 19, 20, 22, 33, 27, 31, 27, 19, 30, 21])
    $('#calendar').datetimepicker({ format: 'L', inline: true })
    $('#chat-box').overlayScrollbars({ height: '250px' })
    var salesChartCanvas = document.getElementById('revenue-chart-canvas').getContext('2d')
    var salesChartData = { labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'], datasets: [{ label: 'Digital Goods', backgroundColor: 'rgba(60,141,188,0.9)', borderColor: 'rgba(60,141,188,0.8)', pointRadius: false, pointColor: '#3b8bba', pointStrokeColor: 'rgba(60,141,188,1)', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(60,141,188,1)', data: [28, 48, 40, 19, 86, 27, 90] }, { label: 'Electronics', backgroundColor: 'rgba(210, 214, 222, 1)', borderColor: 'rgba(210, 214, 222, 1)', pointRadius: false, pointColor: 'rgba(210, 214, 222, 1)', pointStrokeColor: '#c1c7d1', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(220,220,220,1)', data: [65, 59, 80, 81, 56, 55, 40]}] }
    var salesChartOptions = { maintainAspectRatio: false, responsive: true, legend: { display: false }, scales: { xAxes: [{ gridLines: { display: false}}], yAxes: [{ gridLines: { display: false}}]} }
    var salesChart = new Chart(salesChartCanvas, { type: 'line', data: salesChartData, options: salesChartOptions })
    var pieChartCanvas = $('#sales-chart-canvas').get(0).getContext('2d')
    var pieData = { labels: ['Instore Sales', 'Download Sales', 'Mail-Order Sales'], datasets: [{ data: [30, 12, 20], backgroundColor: ['#f56954', '#00a65a', '#f39c12']}] }
    var pieOptions = { legend: { display: false }, maintainAspectRatio: false, responsive: true }
    var pieChart = new Chart(pieChartCanvas, { type: 'doughnut', data: pieData, options: pieOptions })
    var salesGraphChartCanvas = $('#line-chart').get(0).getContext('2d')
    var salesGraphChartData = { labels: ['2011 Q1', '2011 Q2', '2011 Q3', '2011 Q4', '2012 Q1', '2012 Q2', '2012 Q3', '2012 Q4', '2013 Q1', '2013 Q2'], datasets: [{ label: 'Digital Goods', fill: false, borderWidth: 2, lineTension: 0, spanGaps: true, borderColor: '#efefef', pointRadius: 3, pointHoverRadius: 7, pointColor: '#efefef', pointBackgroundColor: '#efefef', data: [2666, 2778, 4912, 3767, 6810, 5670, 4820, 15073, 10687, 8432]}] }
    var salesGraphChartOptions = { maintainAspectRatio: false, responsive: true, legend: { display: false }, scales: { xAxes: [{ ticks: { fontColor: '#efefef' }, gridLines: { display: false, color: '#efefef', drawBorder: false}}], yAxes: [{ ticks: { stepSize: 5000, fontColor: '#efefef' }, gridLines: { display: true, color: '#efefef', drawBorder: false}}]} }
    var salesGraphChart = new Chart(salesGraphChartCanvas, { type: 'line', data: salesGraphChartData, options: salesGraphChartOptions })
})