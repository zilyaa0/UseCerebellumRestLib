namespace CerebellumRestLib.Models.Enums
{
    ///"{номер статуса | 1 - новое, 2 -назначено, 3 - обратная связь, 4 - выполнено}"
    public enum TaskStatus : byte
    {
        /// <summary>
        /// Неопределено (0)
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// новое (1)
        /// </summary>
        New = 1,
        /// <summary>
        /// назначенно (2)
        /// </summary>
        Assigned = 2,
        /// <summary>
        /// обратная связь (3)
        /// </summary>
        CallBack = 3,
        /// <summary>
        /// выполнено (4)
        /// </summary>
        Successful = 4,
        /// <summary>
        /// Просрочено (5)
        /// </summary>
        OverDue = 5,
        /// <summary>
        /// Проблема необнаружена (6)
        /// </summary>
        NoProblem = 6

    }
}