
/*********************************************************************
 *     Métodos que pausan el video al cerrar modal lo reproduce     *
 *********************************************************************/
$('#ModalConvergenteVideo').on('hide.bs.modal', function(e) {
    var $if = $(e.delegateTarget).find('iframe');
    var src = $if.attr("src");
    $if.attr("src", '/empty.html');
    $if.attr("src", src);
});

$('#ModalAsimiladorVideo').on('hide.bs.modal', function(e) {
    var $if = $(e.delegateTarget).find('iframe');
    var src = $if.attr("src");
    $if.attr("src", '/empty.html');
    $if.attr("src", src);
});

$('#ModalDivergenteVideo').on('hide.bs.modal', function(e) {
    var $if = $(e.delegateTarget).find('iframe');
    var src = $if.attr("src");
    $if.attr("src", '/empty.html');
    $if.attr("src", src);
});

$('#ModalAcomodadorVideo').on('hide.bs.modal', function(e) {
    var $if = $(e.delegateTarget).find('iframe');
    var src = $if.attr("src");
    $if.attr("src", '/empty.html');
    $if.attr("src", src);
});


/************************************************************************************
 * Método encargado de obtener el recinto con base en los parámetros especificados. *
 ************************************************************************************/
 function calcularRecinto(){
     /*Se elimina el contenido del div que muestra la respuesta*/
     $('#recintoMessage').html("");

     /*Captura los datos de los combos respectivos*/
     var datoComboSexo = $("#RSexo").val();
     var datoComboPromedio = $("#numPromedioEstilo").val();
     var datoComboEstilo = $("#REstilo").val();

     /*Válida si el usuario envío un dato vacío, una cadena de texto o incluso
     caracteres especiales en el campo del promedio*/
     if (datoComboPromedio != '') {
         /*Se valida si el dato ingresado por el usuario es mayor a cero*/
         if (datoComboPromedio > 0) {
             /*Muestra el gif de cargando antes de mostrar el resultado de los datos*/
             $('#loadRecinto').show();

             /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
             que no se escogió una opción*/
             if (datoComboSexo == null) {
                 /*Cuando se requiere mostrar un mensaje se debe ocultar el gif de carga*/
                 $('#loadRecinto').hide();

                 /*Se crea un div para mostrar los mensajes de error*/
                 var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el sexo !!!</div>";
                 $('#recintoMessage').html(salida);
             }else {
                 /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
                 que no se escogió una opción*/
                 if (datoComboEstilo == null) {
                     /*Cuando se requiere mostrar un mensaje se debe ocultar el gif de carga*/
                     $('#loadRecinto').hide();

                     /*Se crea un div para mostrar los mensajes de error*/
                     var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el estilo !!!</div>";
                     $('#recintoMessage').html(salida);
                 }else {
                     /*Cuando se requiere mostrar un mensaje se debe ocultar el gif de carga*/
                     $('#loadRecinto').hide();

                     /*Se accede a los datos requeridos de manera asincrona*/
                     $.ajax({
                       url: './business/estiloSexoPromedioRecintoAction.php',
                       type: 'POST',
                       dataType: 'text',
                       data: {'obtenerDatos' : 'obtenerDatos'},
                       beforeSend: function() {
                           $('#loadRecinto').show();/*Se muestra el gif de carga antes de
                            solicitar los datos a la bd*/
                       }
                     })
                     .done(function(resp){
                        /*Convierte el objeto codificado en un objeto json*/
                        var datos = JSON.parse(resp);
                        var datosComparados = [];

                        /*Variables*/
                        var sexoProcesado = 0,promedioProcesado = 0,estiloProcesado = 0,
                        resultado = 0, sexo = 0;

                        /*Se recorre el arreglo para procesar los datos que son requeridos*/
                        for (var i = 0; i < datos.Data.length; i++) {
                            /*Se valida el sexo para hacer la resta del valor respectivo,
                            y elevarlo al cuadrado como parte del algoritmo de euclides*/
                            if (datos.Data[i].sexo == 'M') {
                                sexo = 1; //Sexo Masculino
                                /*Se realiza la resta de los valores respectivos y posteriormente
                                se elevan al cuadrado para obtener el resultado positivo,
                                según la formula de euclides*/
                                sexoProcesado = Math.pow((datoComboSexo - sexo) , 2);
                            }else {
                                sexo = 2;//Sexo Femenino
                                /*Se realiza la resta de los valores respectivos y posteriormente
                                se elevan al cuadrado para obtener el resultado positivo,
                                según la formula de euclides*/
                                sexoProcesado = Math.pow((datoComboSexo - sexo) , 2);
                            }

                            /*Con base en el estilo de aprendizaje se hace la resta del
                            valor respectivo de acuerdo a el estilo de aprendizaje*/
                            switch (datos.Data[i].estilo) {
                                case 'ACOMODADOR': //Acomodador tiene el valor de 4
                                    estiloProcesado = Math.pow((datoComboEstilo - 4) , 2);
                                    break;
                                case 'DIVERGENTE': //Divergente tiene el valor de 1
                                    estiloProcesado = Math.pow((datoComboEstilo - 1) , 2);
                                    break;
                                case 'ASIMILADOR': //Divergente tiene el valor de 3
                                    estiloProcesado = Math.pow((datoComboEstilo - 3) , 2);
                                    break;
                                default: //Divergente tiene el valor de 2
                                    estiloProcesado = Math.pow((datoComboEstilo - 2) , 2);
                                    break;
                            }

                            /*Se hace la resta respectiva del promedio y se eleva al cuadrado
                            como parte del algoritmo de euclides*/
                            promedioProcesado = Math.pow((datoComboPromedio - datos.Data[i].promedio) , 2);

                            /*En esta parte se suman todos los valores anteriormente
                            procesados y se saca raíz cuadrada para completar el algoritmo
                            de euclides*/
                            resultado = Math.sqrt((sexoProcesado + promedioProcesado + estiloProcesado))

                            /*Como se trabaja con muchos registros se utiliza un vector
                            para almacenar el mejor dato.
                            Se valida si el vector esta vacío para asignar el primer dato*/
                            if (datosComparados.length == 0) {
                                datosComparados.push(sexoProcesado);
                                datosComparados.push(promedioProcesado)
                                datosComparados.push(estiloProcesado)
                                datosComparados.push(datos.Data[i].estilo)
                                datosComparados.push(datos.Data[i].recinto)
                                datosComparados.push(resultado)
                            }else {
                                /*Si ya existe un dato en el arreglo de datos comparados,
                                lo que hará es comparar el resultado final del nuevo dato
                                con el resultado final del dato almacenado en el arreglo*/
                                if (resultado < datosComparados[5]) {
                                    datosComparados[0] = sexoProcesado;
                                    datosComparados[1] = promedioProcesado;
                                    datosComparados[2] = estiloProcesado;
                                    datosComparados[3] = datos.Data[i].estilo;
                                    datosComparados[4] = datos.Data[i].recinto;
                                    datosComparados[5] = resultado;
                                }//cierre if
                            }//cierre else
                        }//cierre for

                        /*Se oculta el gif de carga para mostrar los datos*/
                        $('#loadRecinto').hide();

                        /*Se muestra el div con los datos correspondientes*/
                        var salida = "<div class='alert alert-success' role'alert'>Su recinto es : " + datosComparados[4] + "</div>";
                        $('#recintoMessage').html(salida);

                     }).fail( function(error, textStatus, errorThrown) {
                         console.log(error.status); //Check console for output
                         //$("#loadIMg").hide();//#datos es un div
                     });
                 }//cierre else 2
             }//cierre else 3
         }else {
             /*Se crea un div para mostrar los mensajes de error*/
             var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
             "debe ser mayor o igual a 1 !!!</div>";
             $('#recintoMessage').html(salida);
         }
     }else {
         var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
         "debe ser un dato númerico !!!</div>";
         $('#recintoMessage').html(salida);
     }
 }

 /********************************************************************************
  * Método encargado de obtener el sexo con base en los parámetros especificados.*
  ********************************************************************************/
 function calcularSexo(){
     /*Se elimina el contenido del div que muestra la respuesta*/
     $('#sexoMessage').html("");

     /*Captura los datos de los combos respectivos*/
     var datoComboRecinto = $("#SelectRecinto").val();
     var datoComboPromedio = $("#numPromedioSexo").val();
     var datoComboEstilo = $("#SEstilo").val();

     /*Muestra el gif de cargando antes de mostrar el resultado de los datos*/
     $('#loadSexo').show();

     /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
     que no se escogió una opción*/
     if (datoComboRecinto == null) {
         /*Cuando se requiere mostrar un mensaje se debe ocultar el gif de carga*/
         $('#loadSexo').hide();

         /*Se muestra un mensaje error en un div*/
         var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el recinto !!!</div>";
         $('#sexoMessage').html(salida);
     }else {
         if (datoComboEstilo == null) {
             /*Cuando se requiere mostrar un mensaje se debe ocultar el gif de carga*/
             $('#loadSexo').hide();

             /*Se muestra un mensaje error en un div*/
             var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el estilo !!!</div>";
             $('#sexoMessage').html(salida);
         }else {
             /*Se oculta el gif de carga por que se va a obtener y procesar los datos*/
             $('#loadSexo').hide();

             /*Válida si el usuario envío un dato vacío, una cadena de texto o incluso
             caracteres especiales en el campo del promedio*/
             if (datoComboPromedio != '') {
                 /*Se valida si el dato ingresado por el usuario es mayor a cero*/
                 if (datoComboPromedio > 0) {
                     /*Se accede a los datos requeridos de manera asincrona*/
                     $.ajax({
                       url: './business/estiloSexoPromedioRecintoAction.php',
                       type: 'POST',
                       dataType: 'text',
                       data: {'obtenerDatos' : 'obtenerDatos'},
                       beforeSend: function() {
                           $('#loadSexo').show();//Se muestra el gif de carga antes de pedir los datos
                       }
                     })
                     .done(function(resp){
                         /*Convierte el objeto codificado en un objeto json*/
                         var datos = JSON.parse(resp);
                         var datosComparados = [];

                         //variables
                         var recintoProcesado = 0, promedioProcesado = 0,estiloProcesado = 0,
                         resultado = 0, sexo = 0;

                         /*Se recorre el arreglo para procesar los datos que son requeridos*/
                         for (var i = 0; i < datos.Data.length; i++) {
                             /*Se valida el recinto para hacer la resta del valor respectivo,
                             y elevarlo al cuadrado como parte del algoritmo de euclides*/
                             if (datos.Data[i].recinto == 'Turrialba') {
                                 recintoProcesado = Math.pow((datoComboRecinto - 1) , 2);
                             }else {
                                 recintoProcesado = Math.pow((datoComboRecinto - 2) , 2);
                             }

                             /*Se valida el estilo de aprendizaje para hacer la resta del valor
                             respectivo, y elevarlo al cuadrado como parte del algoritmo de euclides*/
                             switch (datos.Data[i].estilo) {
                                 case 'ACOMODADOR': //Divergente tiene el valor de 4
                                    estiloProcesado = Math.pow((datoComboEstilo - 4) , 2);
                                    break;
                                 case 'DIVERGENTE': //Divergente tiene el valor de 1
                                    estiloProcesado = Math.pow((datoComboEstilo - 1) , 2);
                                    break;
                                 case 'ASIMILADOR': //Divergente tiene el valor de 3
                                    estiloProcesado = Math.pow((datoComboEstilo - 3) , 2);
                                    break;
                                 default: //Convergente tiene el valor de 2
                                    estiloProcesado = Math.pow((datoComboEstilo - 2) , 2);
                                    break;
                             }

                             /*Se valida el promedio para hacer la resta del valor respectivo,
                             y elevarlo al cuadrado como parte del algoritmo de euclides*/
                             promedioProcesado = Math.pow((datoComboPromedio - datos.Data[i].promedio) , 2);

                             /*En esta parte se suman todos los valores anteriormente
                             procesados y se saca raíz cuadrada para completar el algoritmo
                             de euclides*/
                             resultado = Math.sqrt((promedioProcesado + recintoProcesado + estiloProcesado))

                             /*Como se trabaja con muchos registros se utiliza un vector
                             para almacenar el mejor dato.
                             Se valida si el vector esta vacío para asignar el primer dato*/
                             if (datosComparados.length == 0) {
                                 datosComparados.push(promedioProcesado);
                                 datosComparados.push(recintoProcesado)
                                 datosComparados.push(estiloProcesado)
                                 datosComparados.push(datos.Data[i].sexo)
                                 datosComparados.push(resultado)
                             }else {
                                 /*Si ya existe un dato en el arreglo de datos comparados,
                                 lo que hará es comparar el resultado final del nuevo dato
                                 con el resultado final del dato almacenado en el arreglo*/
                                 if (resultado < datosComparados[4]) {
                                     datosComparados[0] = promedioProcesado;
                                     datosComparados[1] = recintoProcesado;
                                     datosComparados[2] = estiloProcesado;
                                     datosComparados[3] = datos.Data[i].sexo;
                                     datosComparados[4] = resultado;
                                 }//cierre if
                             }//cierre else
                         }//cierre for

                         /*Oculta el gif de carga para mostrar el resultado*/
                         $('#loadSexo').hide();

                         /*Muestra el resultado en un div*/
                         var salida = "<div class='alert alert-success' role'alert'>Su sexo es : " + datosComparados[3] + "</div>";
                         $('#sexoMessage').html(salida);

                     }).fail( function(error, textStatus, errorThrown) {
                         console.log(error.status); //Check console for output
                         //$("#loadIMg").hide();//#datos es un div
                     });
                 }else {
                     /*Se crea un div para mostrar los mensajes de error*/
                     var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
                     "debe ser mayor o igual a 1 !!!</div>";
                     $('#sexoMessage').html(salida);
                 }
             }else {
                 var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
                 "debe ser un dato númerico !!!</div>";
                 $('#sexoMessage').html(salida);
             }
         }//cierre else 2
     }//cierre else 1
 }

/************************************************************************************************
* Método encargado de obtener el estilo de aprendizaje usando los datos del algoritmo original.*
************************************************************************************************/
function calcularEstiloAprendizajeConDatosDeColumnas(){
    /*Se elimina el contenido del div que muestra la respuesta*/
    $('#apreMessage').html("");

    /*Captura los datos de los combos respectivos*/
	ec = parseInt(document.estilo.c5.value)+parseInt(document.estilo.c9.value)+parseInt(document.estilo.c13.value)+parseInt(document.estilo.c17.value)+parseInt(document.estilo.c25.value)+parseInt(document.estilo.c29.value);
	or = parseInt(document.estilo.c2.value)+parseInt(document.estilo.c10.value)+parseInt(document.estilo.c22.value)+parseInt(document.estilo.c26.value)+parseInt(document.estilo.c30.value)+parseInt(document.estilo.c34.value);
	ca = parseInt(document.estilo.c7.value)+parseInt(document.estilo.c11.value)+parseInt(document.estilo.c15.value)+parseInt(document.estilo.c19.value)+parseInt(document.estilo.c31.value)+parseInt(document.estilo.c35.value);
	ea = parseInt(document.estilo.c4.value)+parseInt(document.estilo.c12.value)+parseInt(document.estilo.c24.value)+parseInt(document.estilo.c28.value)+parseInt(document.estilo.c32.value)+parseInt(document.estilo.c36.value);

    /*Se accede a los datos requeridos de manera asincrona*/
    $.ajax({
      url: './business/recintoEstiloAction.php',
      type: 'POST',
      dataType: 'text',
      data: {'obtenerDatos' : 'obtenerDatos'},
      beforeSend: function() {
          $('#loadEstilo').show(); /*Se muestra el gif de carga antes de obtener los datos*/
      }
    })
    .done(function(resp){
        /*Convierte el objeto codificado en un objeto json*/
        var datos = JSON.parse(resp);

        var datosComparados = [];

        //variables
        var ecProcesado = 0, orProcesado = 0, caProcesado = 0, eaProcesado = 0, resultado = 0;

        /*Se recorre el arreglo para procesar los datos que son requeridos*/
        for (var i = 0; i < datos.Data.length; i++) {
            /*Se valida las columnas del formulario brindado para hacer la resta del valor respectivo,
            y elevarlo al cuadrado como parte del algoritmo de euclides*/
            caProcesado = Math.pow((ca - datos.Data[i].ca) , 2);
            ecProcesado = Math.pow((ec - datos.Data[i].ec) , 2);
            eaProcesado = Math.pow((ea - datos.Data[i].ea) , 2);
            orProcesado = Math.pow((or - datos.Data[i].or_r) , 2);

            /*En esta parte se suman todos los valores anteriormente
            procesados y se saca raíz cuadrada para completar el algoritmo
            de euclides*/
            resultado = Math.sqrt((caProcesado + ecProcesado + eaProcesado + orProcesado))

            /*Como se trabaja con muchos registros se utiliza un vector
            para almacenar el mejor dato.
            Se valida si el vector esta vacío para asignar el primer dato*/
            if (datosComparados.length == 0) {
                datosComparados.push(caProcesado);
                datosComparados.push(ecProcesado)
                datosComparados.push(eaProcesado)
                datosComparados.push(orProcesado)
                datosComparados.push(datos.Data[i].estilo)
                datosComparados.push(resultado)
            }else {
                /*Si ya existe un dato en el arreglo de datos comparados,
                lo que hará es comparar el resultado final del nuevo dato
                con el resultado final del dato almacenado en el arreglo*/
                if (resultado < datosComparados[5]) {
                    datosComparados[0] = caProcesado;
                    datosComparados[1] = ecProcesado;
                    datosComparados[2] = eaProcesado;
                    datosComparados[3] = orProcesado;
                    datosComparados[4] = datos.Data[i].estilo;
                    datosComparados[5] = resultado;
                }//Cierre if
            }//Cierre else
        }//Cierre del for

        /*Oculta el gif de carga antes de mostar el mensaje*/
        $('#loadEstilo').hide();

        /*Se muestra la respuesta*/
        var salida = "<div class='alert alert-success' role'alert'>Su estilo de aprendizaje es : " + datosComparados[4] + "</div>";
        $('#apreMessage').html(salida);

    }).fail( function(error, textStatus, errorThrown) {
        console.log(error.status); //Check console for output
        //$("#loadIMg").hide();//#datos es un div
    });
}


/******************************************************************************************************
* Método encargado de obtener el estilo de aprendizaje usando los parámetros especiales especificados.*
*******************************************************************************************************/
function calcularEstiloAprendizajeCustom(){
    /*Se elimina el contenido del div que muestra la respuesta*/
    $('#estiloCustomMessage').html("");

    /*Captura los datos de los combos respectivos*/
    var datoComboSexoCustom = $("#SSexoCustom").val();
    var datoComboPromedio = $("#numPromedioSexoCustom").val();
    var datoComboRecintoCustom = $("#SRecintoCustom").val();

    //Se muestra el gif de carga antes de capturar los datos
    $('#loadEstiloCustom').show();

    /*Válida si el usuario envío un dato vacío, una cadena de texto o incluso
    caracteres especiales en el campo del promedio*/
    if (datoComboPromedio != '') {
        /*Se valida si el dato ingresado por el usuario es mayor a cero*/
        if (datoComboPromedio > 0) {
            /*Se accede a los datos requeridos de manera asincrona*/
            $.ajax({
              url: './business/estiloSexoPromedioRecintoAction.php',
              type: 'POST',
              dataType: 'text',
              data: {'obtenerDatos' : 'obtenerDatos'},
              beforeSend: function() {
                  $('#loadEstiloCustom').show();//Se muestra el gif de carga antes de capturar los datos
              }
            })
            .done(function(resp){
                /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
                que no se escogió una opción*/
                if (datoComboSexoCustom == null) {
                    /*Se oculta el gif de carga*/
                    $('#loadEstiloCustom').hide();

                    /*Se muestra un error*/
                    var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el sexo</div>";
                    $('#estiloCustomMessage').html(salida);
                }else {
                    if (datoComboRecintoCustom == null) {
                        /*Se oculta el gif de carga*/
                        $('#loadEstiloCustom').hide();

                        /*Se muestra un error*/
                        var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger un recinto</div>";
                        $('#estiloCustomMessage').html(salida);
                    }else {
                        /*Convierte el objeto codificado en un objeto json*/
                        var datos = JSON.parse(resp);
                        var datosComparados = [];

                        //Variables
                        var recintoProcesado = 0, promedioProcesado = 0,sexoProcesado = 0,
                        resultado = 0, sexo = 0;

                        /*Se recorre el arreglo para procesar los datos que son requeridos*/
                        for (var i = 0; i < datos.Data.length; i++) {
                            /*Se valida el recinto para hacer la resta del valor respectivo,
                            y elevarlo al cuadrado como parte del algoritmo de euclides*/
                            if (datos.Data[i].recinto == 'Turrialba') {
                                recintoProcesado = Math.pow((datoComboRecintoCustom - 1) , 2);
                            }else {
                                recintoProcesado = Math.pow((datoComboRecintoCustom - 2) , 2);
                            }

                            /*Se valida el sexo para hacer la resta del valor
                            respectivo, y elevarlo al cuadrado como parte del algoritmo de euclides*/
                            if (datos.Data[i].sexo == 'M') {
                                sexo = 1;
                                sexoProcesado = (datoComboSexoCustom - sexo);
                            }else {
                                sexo = 2;
                                sexoProcesado = (datoComboSexoCustom - sexo);
                            }

                            /*Se valida el promedio para hacer la resta del valor respectivo,
                            y elevarlo al cuadrado como parte del algoritmo de euclides*/
                            promedioProcesado = Math.pow((datoComboPromedio - datos.Data[i].promedio) , 2);

                            /*En esta parte se suman todos los valores anteriormente
                            procesados y se saca raíz cuadrada para completar el algoritmo
                            de euclides*/
                            resultado = Math.sqrt((promedioProcesado + recintoProcesado + sexoProcesado))

                            /*Como se trabaja con muchos registros se utiliza un vector
                            para almacenar el mejor dato.
                            Se valida si el vector esta vacío para asignar el primer dato*/
                            if (datosComparados.length == 0) {
                                datosComparados.push(promedioProcesado);
                                datosComparados.push(recintoProcesado)
                                datosComparados.push(sexoProcesado)
                                datosComparados.push(datos.Data[i].estilo)
                                datosComparados.push(resultado)
                            }else {
                                /*Si ya existe un dato en el arreglo de datos comparados,
                                lo que hará es comparar el resultado final del nuevo dato
                                con el resultado final del dato almacenado en el arreglo*/
                                if (resultado < datosComparados[4]) {
                                    datosComparados[0] = promedioProcesado;
                                    datosComparados[1] = recintoProcesado;
                                    datosComparados[2] = sexoProcesado;
                                    datosComparados[3] = datos.Data[i].estilo;
                                    datosComparados[4] = resultado;
                                }//cierre if
                            }//cierre else
                        }//cierre for

                        /*Se oculta el gif de carga ante de mostrar la respuesta*/
                        $('#loadEstiloCustom').hide();

                        /*Se muestra la respuesta*/
                        var salida = "<div class='alert alert-success' role'alert'>Su estilo de aprendizaje es : " + datosComparados[3] + "</div>";
                        $('#estiloCustomMessage').html(salida);
                    }//cierre else 2
                }//cierre else 1

            }).fail( function(error, textStatus, errorThrown) {
                console.log(error.status); //Check console for output
                //$("#loadIMg").hide();//#datos es un div
            });
        }else {
            /*Se oculta el gif de carga*/
            $('#loadEstiloCustom').hide();

            /*Se crea un div para mostrar los mensajes de error*/
            var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
            "debe ser mayor o igual a 1 !!!</div>";
            $('#estiloCustomMessage').html(salida);
        }
    }else {
        /*Se oculta el gif de carga*/
        $('#loadEstiloCustom').hide();

        var salida = "<div class='alert alert-danger' role'alert'>Error, el valor del promedio "+
        "debe ser un dato númerico !!!</div>";
        $('#estiloCustomMessage').html(salida);
    }
}

/*************************************************************************************************
* Método encargado de obtener el tipo de profesor usando los parámetros especiales especificados.*
**************************************************************************************************/
function calcularTipoProfesor(){
    /*Se elimina el contenido del div que muestra la respuesta*/
    $('#tipoProfesor').html("");

    /*Captura los datos de los combos respectivos*/
    var comboEdadProfesor = $("#comboEdadProfesor").val();
    var comboGeneroProfesor = $("#comboGeneroProfesor").val();
    var comboNotaProfesor = $("#comboNotaProfesor").val();
    var comboImparticionCurso = $("#comboImparticionCurso").val();
    var comboAreaProfesor = $("#comboAreaProfesor").val();
    var comboHabilidadProfesor = $("#comboHabilidadProfesor").val();
    var comboExperienciaEnsenanza = $("#comboExperienciaEnsenanza").val();
    var comboExperienciaUso = $("#comboExperienciaUso").val();

    /*Se accede a los datos requeridos de manera asincrona*/
    $.ajax({
      url: './business/profesoresAction.php',
      type: 'POST',
      dataType: 'text',
      data: {'obtenerDatos' : 'obtenerDatos'},
      beforeSend: function() {
          $('#loadProfesor').show();//Se muestra el gif de carga antes de obtene los datos
      }
    })
    .done(function(resp){
        /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
        que no se escogió una opción*/
        if (comboEdadProfesor == null) {
            /*Se oculta el gif de carga*/
            $('#loadProfesor').hide();

            /*Se muestra un determinado error*/
            var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger una opción de edad del profesor</div>";
            $('#tipoProfesor').html(salida);
        }else {
            if (comboGeneroProfesor == null) {
                /*Se oculta el gif de carga*/
                $('#loadProfesor').hide();

                /*Se muestra un determinado error*/
                var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el género</div>";
                $('#tipoProfesor').html(salida);
            }else {
                if (comboNotaProfesor == null) {
                    /*Se oculta el gif de carga*/
                    $('#loadProfesor').hide();

                    /*Se muestra un determinado error*/
                    var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger una nota de evaluación</div>";
                    $('#tipoProfesor').html(salida);
                }else {
                    if (comboImparticionCurso == null) {
                        /*Se oculta el gif de carga*/
                        $('#loadProfesor').hide();

                        /*Se muestra un determinado error*/
                        var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger la cantidad de veces que el docente impartió el curso</div>";
                        $('#tipoProfesor').html(salida);
                    }else {
                        if (comboAreaProfesor == null) {
                            /*Se oculta el gif de carga*/
                            $('#loadProfesor').hide();

                            /*Se muestra un determinado error*/
                            var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger un área de especialización</div>";
                            $('#tipoProfesor').html(salida);
                        }else {
                            if (comboHabilidadProfesor == null) {
                                /*Se oculta el gif de carga*/
                                $('#loadProfesor').hide();

                                /*Se muestra un determinado error*/
                                var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el nivel de habilidad del profesor en la computadora</div>";
                                $('#tipoProfesor').html(salida);
                            }else {
                                if (comboExperienciaUso == null) {
                                    /*Se oculta el gif de carga*/
                                    $('#loadProfesor').hide();

                                    /*Se muestra un determinado error*/
                                    var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger una opción sobre la experiencia del docente usando sitios web para la enseñanza</div>";
                                    $('#tipoProfesor').html(salida);
                                }else {
                                    if (comboExperienciaEnsenanza == null) {
                                        /*Se oculta el gif de carga*/
                                        $('#loadProfesor').hide();

                                        /*Se muestra un determinado error*/
                                        var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger una opción sobre la experiencia del docente usando sitios web</div>";
                                        $('#tipoProfesor').html(salida);
                                    }else {
                                        /*Convierte el objeto codificado en un objeto json*/
                                        var datos = JSON.parse(resp);
                                        var datosComparados = [];

                                        //Variables
                                        var edadProcesada = 0, generoProcesado = 0, notaProcesado = 0,
                                        imparticionCursoProcesado = 0, areaProcesado = 0, habilidadProfesorProcesado = 0,
                                        experienciaEnsenanzaProcesado = 0, experienciaUsoProcesado = 0,genero = 0, nota = 0,
                                        area = 0, habilidad = 0, experiencia = 0, experienciaEnsenanza = 0;

                                        /*Se recorre el arreglo para procesar los datos que son requeridos*/
                                        for (var i = 0; i < datos.Data.length; i++) {

                                            /*Se valida el valor para hacer la resta del valor respectivo,
                                            y elevarlo al cuadrado como parte del algoritmo de euclides*/
                                            edadProcesada = Math.pow((comboEdadProfesor - datos.Data[i].a) , 2);//Edad

                                            //Opciones de género
                                            switch (datos.Data[i].b) {
                                                case "M":
                                                    genero = 1;
                                                    generoProcesado = Math.pow((comboGeneroProfesor - genero) , 2);//Género
                                                    break;
                                                case "F":
                                                    genero = 2;
                                                    generoProcesado = Math.pow((comboGeneroProfesor - genero) , 2);//Género
                                                    break;
                                                default:
                                                    genero = 3;
                                                    generoProcesado = Math.pow((comboGeneroProfesor - genero) , 2);//Género
                                                    break;
                                            }

                                            //Opciones de nota de autoevaluación
                                            switch (datos.Data[i].c) {
                                                case "A":
                                                    nota = 1;
                                                    notaProcesado = Math.pow((comboNotaProfesor - nota) , 2);//Nota de autoevaluación
                                                    break;
                                                case "B":
                                                    nota = 2;
                                                    notaProcesado = Math.pow((comboNotaProfesor - nota) , 2);//Nota de autoevaluación
                                                    break;
                                                default:
                                                    nota = 3;
                                                    notaProcesado = Math.pow((comboNotaProfesor - nota) , 2);//Nota de autoevaluación
                                                    break;
                                            }

                                            //Opciones de nota de autoevaluación
                                            switch (datos.Data[i].d) {
                                                case "A":
                                                    nota = 1;
                                                    imparticionCursoProcesado = Math.pow((comboImparticionCurso - nota) , 2);//Nota de autoevaluación
                                                    break;
                                                case "B":
                                                    nota = 2;
                                                    imparticionCursoProcesado = Math.pow((comboImparticionCurso - nota) , 2);//Nota de autoevaluación
                                                    break;
                                                default:
                                                    nota = 3;
                                                    imparticionCursoProcesado = Math.pow((comboImparticionCurso - nota) , 2);//Nota de autoevaluación
                                                    break;
                                            }

                                            //Opciones de Área de especialización
                                            switch (datos.Data[i].e) {
                                                case "ND":
                                                    area = 1;
                                                    areaProcesado = Math.pow((comboAreaProfesor - area) , 2);//Área de especialización
                                                    break;
                                                case "DM":
                                                    area = 2;
                                                    areaProcesado = Math.pow((comboAreaProfesor - area) , 2);//Área de especialización
                                                    break;
                                                default:
                                                    area = 3;
                                                    areaProcesado = Math.pow((comboAreaProfesor - area) , 2);//Área de especialización
                                                    break;
                                            }

                                            //Opciones de habilidad en la computadora
                                            switch (datos.Data[i].f) {
                                                case "I":
                                                    habilidad = 1;
                                                    habilidadProfesorProcesado = Math.pow((comboHabilidadProfesor - habilidad) , 2);//Habilidad en la computadora
                                                    break;
                                                case "A":
                                                    habilidad = 2;
                                                    habilidadProfesorProcesado = Math.pow((comboHabilidadProfesor - habilidad) , 2);//Habilidad en la computadora
                                                    break;
                                                default:
                                                    habilidad = 3;
                                                    habilidadProfesorProcesado = Math.pow((comboHabilidadProfesor - habilidad) , 2);//Habilidad en la computadora
                                                    break;
                                            }

                                            //Opciones de experiencia del docente en tecnología web para la enseñanza
                                            switch (datos.Data[i].g) {
                                                case "N":
                                                    experienciaEnsenanza = 1;
                                                    experienciaEnsenanzaProcesado = Math.pow((comboExperienciaEnsenanza - experienciaEnsenanza) , 2);//Experiencia del docente en tecnología web para la enseñanza
                                                    break;
                                                case "S":
                                                    experienciaEnsenanza = 2;
                                                    experienciaEnsenanzaProcesado = Math.pow((comboExperienciaEnsenanza - experienciaEnsenanza) , 2);//Experiencia del docente en tecnología web para la enseñanza
                                                    break;
                                                default:
                                                    experienciaEnsenanza = 3;
                                                    experienciaEnsenanzaProcesado = Math.pow((comboExperienciaEnsenanza - experienciaEnsenanza) , 2);//Experiencia del docente en tecnología web para la enseñanza
                                                    break;
                                            }

                                            //Opciones de experiencia del docente usando sitios web
                                            switch (datos.Data[i].h) {
                                                case "A":
                                                    experiencia = 1;
                                                    experienciaUsoProcesado = Math.pow((comboExperienciaUso - experiencia) , 2);//Experiencia del docente usando sitios web
                                                    break;
                                                case "H":
                                                    experiencia = 2;
                                                    experienciaUsoProcesado = Math.pow((comboExperienciaUso - experiencia) , 2);//Experiencia del docente usando sitios web
                                                    break;
                                                default:
                                                    experiencia = 3;
                                                    experienciaUsoProcesado = Math.pow((comboExperienciaUso - experiencia) , 2);//Experiencia del docente usando sitios web
                                                    break;
                                            }


                                            /*En esta parte se suman todos los valores anteriormente
                                            procesados y se saca raíz cuadrada para completar el algoritmo
                                            de euclides*/
                                            resultado = Math.sqrt((edadProcesada + generoProcesado + notaProcesado +
                                            imparticionCursoProcesado + areaProcesado + habilidadProfesorProcesado +
                                            experienciaEnsenanzaProcesado + experienciaUsoProcesado))

                                            /*Como se trabaja con muchos registros se utiliza un vector
                                            para almacenar el mejor dato.
                                            Se valida si el vector esta vacío para asignar el primer dato*/
                                            if (datosComparados.length == 0) {
                                                datosComparados.push(edadProcesada);
                                                datosComparados.push(generoProcesado);
                                                datosComparados.push(notaProcesado);
                                                datosComparados.push(imparticionCursoProcesado);
                                                datosComparados.push(areaProcesado);
                                                datosComparados.push(habilidadProfesorProcesado);
                                                datosComparados.push(experienciaEnsenanzaProcesado);
                                                datosComparados.push(experienciaUsoProcesado);
                                                datosComparados.push(datos.Data[i].class);
                                                datosComparados.push(resultado);
                                            }else {
                                                /*Si ya existe un dato en el arreglo de datos comparados,
                                                lo que hará es comparar el resultado final del nuevo dato
                                                con el resultado final del dato almacenado en el arreglo*/
                                                if (resultado < datosComparados[9]) {
                                                    datosComparados[0] = edadProcesada;
                                                    datosComparados[1] = generoProcesado;
                                                    datosComparados[2] = notaProcesado;
                                                    datosComparados[3] = imparticionCursoProcesado;
                                                    datosComparados[4] = areaProcesado;
                                                    datosComparados[5] = habilidadProfesorProcesado;
                                                    datosComparados[6] = experienciaEnsenanzaProcesado;
                                                    datosComparados[7] = experienciaUsoProcesado;
                                                    datosComparados[8] = datos.Data[i].class;
                                                    datosComparados[9] = resultado;
                                                }
                                            }//cierre else
                                        }//cierre for

                                        var respuesta = "";

                                        /*Se oculta el gif de carga*/
                                        $('#loadProfesor').hide();

                                        switch (datosComparados[8]) {
                                            case "Beginner":
                                                respuesta = "Principiante";
                                                break;
                                            case "Intermediate":
                                                respuesta = "Intermedio";
                                                break;
                                            default:
                                                respuesta = "Avanzado";
                                                break;
                                        }

                                        /*Se muestra el mensaje con la respuesta*/
                                        var salida = "<div class='alert alert-success' role'alert'>El tipo de profesor es : " + respuesta + "</div>";
                                        $('#tipoProfesor').html(salida);
                                    }
                                }//cierre else
                            }//cierre else
                        }//cierre else
                    }//cierre else
                }//cierre else 2
            }//cierre else 1
        }

    }).fail( function(error, textStatus, errorThrown) {
        console.log(error.status); //Check console for output
        //$("#loadIMg").hide();//#datos es un div
    });
}

/********************************************************************************************
* Método encargado de obtener el tipo de red usando los parámetros especiales especificados.*
*********************************************************************************************/
function calcularRed(){
    /*Se elimina el contenido del div que muestra la respuesta*/
    $('#redes').html("");

    /*Captura los datos de los combos respectivos*/
    var datoConfiabilidad = $("#confiabilidad").val();
    var datoNumeroDeLinks = $("#numeroDeLinks").val();
    var datoComboCapacidad = $("#SCapacidad").val();
    var datoComboCosto = $("#SCosto").val();

    /*Válida si el usuario envío un dato vacío, una cadena de texto o incluso
    caracteres especiales en el campo del níumero de links*/
    if (datoNumeroDeLinks != '') {
        /*Se valida si el dato ingresado por el usuario es mayor a cero*/
        if (datoNumeroDeLinks > 0) {
            /*Válida si el usuario envío un dato vacío, una cadena de texto o incluso
            caracteres especiales en el campo confiabilidad de la red*/
            if (datoConfiabilidad != '') {
                /*Se valida si el dato ingresado por el usuario es mayor a cero*/
                if (datoConfiabilidad > 0) {
                    /*Se accede a los datos requeridos de manera asincrona*/
                    $.ajax({
                      url: './business/redesAction.php',
                      type: 'POST',
                      dataType: 'text',
                      data: {'obtenerDatos' : 'obtenerDatos'},
                      beforeSend: function() {
                         $('#loadRedes').show();//Se muestra el gif de carga antes de obtener los datos
                      }
                    })
                    .done(function(resp){
                        /*Valida si alguno de los combos tiene el valor por defecto, lo cual indica
                        que no se escogió una opción*/
                        if (datoComboCapacidad == null) {
                            //Se oculta el gif de carga
                            $('#loadRedes').hide();

                            /*Se muestra un determinado error*/
                            var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger la capacidad total de la red </div>";
                            $('#redes').html(salida);
                        }else {
                            if (datoComboCosto == null) {
                                //Se oculta el gif de carga
                                $('#loadRedes').hide();

                                /*Se muestra un determinado error*/
                                var salida = "<div class='alert alert-danger' role'alert'>Error debe escoger el costo de la red</div>";
                                $('#redes').html(salida);
                            }else {
                                /*Convierte el objeto codificado en un objeto json*/
                                var datos = JSON.parse(resp);
                                var datosComparados = [];

                                //Variables
                                var confiabilidadProcesada = 0, numeroDeLinksProcesado = 0,
                                costoprocesado = 0, capacidadProcesada = 0, resultado = 0,
                                costo = 0, capacidad = 0;

                                /*Se recorre el arreglo para procesar los datos que son requeridos*/
                                for (var i = 0; i < datos.Data.length; i++) {
                                    //Se procesa la capacidad total de la red
                                    switch (datoComboCapacidad) {
                                        case "High":
                                            capacidad = 1;
                                            capacidadProcesada = Math.pow((capacidad - datos.Data[i].capacity) , 2);
                                            break;
                                        case "Medium":
                                            capacidad = 2;
                                            capacidadProcesada = Math.pow((capacidad - datos.Data[i].capacity) , 2);
                                            break;
                                        default:
                                            capacidad = 3;
                                            capacidadProcesada = Math.pow((capacidad - datos.Data[i].capacity) , 2);
                                            break;
                                    }

                                    //Se procesa el costo de la red
                                    switch (datoComboCosto) {
                                        case "High":
                                            costo = 1;
                                            costoprocesado = Math.pow((costo - datos.Data[i].costo) , 2);
                                            break;
                                        case "Medium":
                                            costo = 2;
                                            costoprocesado = Math.pow((costo - datos.Data[i].costo) , 2);
                                            break;
                                        default:
                                            costo = 3;
                                            costoprocesado = Math.pow((costo - datos.Data[i].costo) , 2);
                                            break;
                                    }

                                    //Se procesa la confiabilidad
                                    confiabilidadProcesada = Math.pow((datoConfiabilidad - datos.Data[i].reliability) , 2);

                                    //Se procesa el número de liks
                                    numeroDeLinksProcesado = Math.pow((datoNumeroDeLinks - datos.Data[i].numberOfLinks) , 2);

                                    /*En esta parte se suman todos los valores anteriormente
                                    procesados y se saca raíz cuadrada para completar el algoritmo
                                    de euclides*/
                                    resultado = Math.sqrt((confiabilidadProcesada + numeroDeLinksProcesado + capacidadProcesada +
                                    costoprocesado))

                                    /*Como se trabaja con muchos registros se utiliza un vector
                                    para almacenar el mejor dato.
                                    Se valida si el vector esta vacío para asignar el primer dato*/
                                    if (datosComparados.length == 0) {
                                        datosComparados.push(confiabilidadProcesada);
                                        datosComparados.push(numeroDeLinksProcesado)
                                        datosComparados.push(capacidadProcesada)
                                        datosComparados.push(costoprocesado)
                                        datosComparados.push(datos.Data[i].class)
                                        datosComparados.push(resultado)
                                    }else {
                                        /*Si ya existe un dato en el arreglo de datos comparados,
                                        lo que hará es comparar el resultado final del nuevo dato
                                        con el resultado final del dato almacenado en el arreglo*/
                                        if (resultado < datosComparados[5]) {
                                            datosComparados[0] = confiabilidadProcesada;
                                            datosComparados[1] = numeroDeLinksProcesado;
                                            datosComparados[2] = capacidadProcesada;
                                            datosComparados[3] = costoprocesado;
                                            datosComparados[4] = datos.Data[i].class;
                                            datosComparados[5] = resultado;
                                        }//cierre if
                                    }//cierre else
                                }//cierre for

                                /*Antes de dar una respuesta se oculta el gif de carga*/
                                $('#loadRedes').hide();

                                /*Se muestra la respuesta*/
                                var salida = "<div class='alert alert-success' role'alert'>El tipo de red es : " + datosComparados[4] + "</div>";
                                $('#redes').html(salida);
                            }//cierre else 2
                        }//cierre else 1

                    }).fail( function(error, textStatus, errorThrown) {
                        console.log(error.status); //Check console for output
                        //$("#loadIMg").hide();//#datos es un div
                    });
                }else {
                    /*Se oculta el gif de carga*/
                    $('#loadEstiloCustom').hide();

                    /*Se crea un div para mostrar los mensajes de error*/
                    var salida = "<div class='alert alert-danger' role'alert'>Error, el número correspondiente "+
                    "a la confiabilidad de la red, debe ser mayor o igual a 1 !!!</div>";
                    $('#redes').html(salida);
                }
            }else {
                /*Se oculta el gif de carga*/
                $('#loadEstiloCustom').hide();

                var salida = "<div class='alert alert-danger' role'alert'>Error, el valor correspondiente "+
                "a la confiabilidad de la red debe ser un dato númerico !!!</div>";
                $('#redes').html(salida);
            }
        }else {
            /*Se oculta el gif de carga*/
            $('#loadEstiloCustom').hide();

            /*Se crea un div para mostrar los mensajes de error*/
            var salida = "<div class='alert alert-danger' role'alert'>Error, el número de links "+
            "debe ser mayor o igual a 1 !!!</div>";
            $('#redes').html(salida);
        }
    }else {
        /*Se oculta el gif de carga*/
        $('#loadEstiloCustom').hide();

        var salida = "<div class='alert alert-danger' role'alert'>Error, el valor correspondiente al número de links "+
        "debe ser un dato númerico !!!</div>";
        $('#redes').html(salida);
    }
}

/*Estos métodos detectan el momento en que un específico modal se cierra para
ocultar la alerta*/
$("#ModalProfesor").on("hide.bs.modal", function () {
    $('#tipoProfesor').html("");
});

$("#ModalRecinto").on("hide.bs.modal", function () {
    $('#recintoMessage').html("");
});

$("#ModalSexo").on("hide.bs.modal", function () {
    $('#sexoMessage').html("");
});

$("#ModalEstilo").on("hide.bs.modal", function () {
    $('#apreMessage').html("");
});

$("#ModalEstiloCustom").on("hide.bs.modal", function () {
    $('#estiloCustomMessage').html("");
});

$("#ModalRedes").on("hide.bs.modal", function () {
    $('#redes').html("");
});

/************************************************************************
 *    Esta fución cierra el navbar-toggle cuando preciona una opción    *
 ************************************************************************/
$(function() {
    $('.nav a').on('click', function(){
        if($('.navbar-toggle').css('display') !='none'){
            $('.navbar-toggle').trigger( "click" );
        }
    });
});

/*Se ocultan los gif de carga al iniciar el web site*/
$( document ).ready(function() {
    $('#loadRedes').hide();
    $('#loadEstilo').hide();
    $('#loadProfesor').hide();
    $('#loadEstiloCustom').hide();
    $('#loadSexo').hide();
    $('#loadRecinto').hide();
});
