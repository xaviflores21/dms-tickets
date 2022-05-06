using MediatR;
using Pedidos.Application.Dto.Pedido;
using System;
using System.Collections.Generic;

namespace Pedidos.Application.UseCases.Command.Pedidos.CrearPedido
{
    public class CrearVueloCommand : IRequest<Guid>
    {
        private CrearVueloCommand() { }

        public CrearVueloCommand(List<DetallePedidoDto> detalle)
        {
            Detalle = detalle;
        }

        public List<DetallePedidoDto> Detalle { get; set; }

        

    }
}
