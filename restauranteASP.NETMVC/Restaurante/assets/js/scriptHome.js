$(function() {
	$('#button').on('click', function() {
		let input1 = $('#input1').val();//pega o valor do input pelo id
		let input2 = $('#input2').val();//pega o valor do input pelo id
        let input3 = $('#input3').val();//pega o valor do input pelo id
        let input4 = $('#input4').val();//pega o valor do input pelo id
        let input5 = $('#input5').val();//pega o valor do input pelo id
		if (input1 !== '' && input2 !== '' && input3 !== '' && input4 !== '' && input5 !== '') {//verifica se os inputs estão vazios
			window.location.href = 'cadastro-servico.php'; //se estuver preenchidos ele redireciona para a pagina cadastro-servico
		} else {
			alert('Cliente não encontrado!'); //se nao ele emite uma mensagem de erro
			return false;
		}
	});
});
$(document).ready(function()
                  {
                  $("#servico").change(function()
        {
            if($(this).val() == "Mensalista")
        {
            $("#servicos").show();
            var today = new Date();
            var dy = today.getDate();
            var mt = today.getMonth()+1;
            var yr = today.getFullYear();
            document.getElementById('tempo').value= dy+"-"+mt+"-"+yr;   
            $("#tempo").show();
            var today = new Date();
            var dy = today.getDate();
            var mt = today.getMonth()+2;
            var yr = today.getFullYear();
            document.getElementById('resultadoTempo').value= dy+"-"+mt+"-"+yr;          
            $("#tempo2").show().attr('type', 'time');
            $("#tempo2").show();
			$('#servicos').val("Mensalista");
        }
        if($(this).val() == "Diarista")
        {
            $("#servicos").show();
            var today = new Date();
            var dy = today.getDate();
            var mt = today.getMonth()+1;
            var yr = today.getFullYear();
            document.getElementById('tempo').value= dy+"/"+mt+"/"+yr;
            function diasNoMesSearch(mes, ano) {
                let data = new Date(ano, mes, 0);
                return data.getDate();
            }            
            let mesAtual = new Date().getMonth()+1; //getMonth retorna um array dos meses que vai de 0 a 11, onde 0 é Janeiro, e 11 é Dezembro. a função "diasNoMesSearch" quer receber o numero do mes atual certo. por esses motivo tem +1 no final. 
            let anoAtual = new Date().getFullYear(); //pega o ano completo
            let diasNoMes = diasNoMesSearch(mesAtual, anoAtual); //chama a função!
            let diaAtual = new Date().getDate(); //pega o dia atual.
            if (diaAtual === diasNoMes && mesAtual === 11){  
               diaAtual = 1; //se tivermos no ultimo dia do mês. vamos setar 1 como dia seguinte!
               mesAtual = 1;
            }else{
               diaAtual += +1; //caso não estejamos no ultimo dia do mês, vamos fazer um incremento de +1.
            }
            document.getElementById('resultadoTempo').value=diaAtual+"/"+mesAtual+"/"+anoAtual;             
            $("#tempo").show();
            $("#tempo2").show();
			$('#servicos').val("Diarista");
        }
        if($(this).val() == "Horista")
        {
            $("#servicos").show();
            var today = new Date();
            var dy = today.getDate();
            var mt = today.getMonth()+1;
            var yr = today.getFullYear();
            document.getElementById('tempo').value= dy+"/"+mt+"/"+yr;     
            var today = new Date();
            var dy = today.getDate();
            var mt = today.getMonth()+1;
            var yr = today.getFullYear();
            document.getElementById('resultadoTempo').value= dy+"/"+mt+"/"+yr;             
            $("#tempo").show();                       
            $("#tempo2").show();         
			$('#servicos').val("Horista");
        }
        if($(this).val() == "nada")
        {           
            $("#servicos").hide();    
            $("#tempo").show();
            $("#tempo2").show(); 

        }
            });
                      $("#servicos").hide();
});