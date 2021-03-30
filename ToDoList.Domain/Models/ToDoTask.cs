using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Domain.Models
{
    public class ToDoTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public DateTimeOffset TargetCompletionDateTime { get; set; }
        public string Description { get; set; }
        public int ParentTaskLinkId { get; set; }
        public List<ToDoTask> SubTasks { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        protected ToDoTask()
        {
            CreatedOn = DateTimeOffset.Now;
            LastModifiedOn = DateTimeOffset.Now;
            SubTasks = new List<ToDoTask>();
        }

        public ToDoTask(string taskName, string description, DateTimeOffset targetCompletion, int parentId = 0) : base()
        {
            TaskName = taskName;
            Description = description;
            TargetCompletionDateTime = targetCompletion;
            ParentTaskLinkId = parentId;
        }

        public void AddSubTask(string taskName, string description, DateTimeOffset targetCompletion)
        {
            SubTasks.Add(new ToDoTask(taskName, description, targetCompletion, TaskId));
        }

        public bool RemoveSubTask(ToDoTask task)
        {
            return SubTasks.Remove(task);
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void MarkAsUncompleted()
        {
            IsCompleted = false;
        }

        public void EditDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void UpdateTargetCompletionDate(DateTimeOffset newTarget)
        {
            TargetCompletionDateTime = newTarget;
        }

        public void DeleteTask()
        {
            IsDeleted = true;
        }
    }
}
