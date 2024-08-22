namespace Entity.Dto
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Propiedad para establecer el estado de la petición True | False
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Devuelve un mensaje personalizado
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Devuelve una data de una entidad o listado de la misma
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Información extra, usado en su momento para paginación
        /// </summary>
       
    }
}

