using System;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Model;

namespace TaskManagerApp.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var toDoItems = _toDoItemRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await toDoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var toDoItem = _toDoItemRepository.GetById(id);

            if(toDoItem == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await toDoItem);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _toDoItemRepository.Create(toDoItem);
            return CreatedAtAction(nameof(GetTask), new { id = toDoItem.Id }, toDoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] ToDoItem toDoItem)
        {
            try
            {
                if (id != toDoItem.Id)
                    return BadRequest("Task ID mismatch");

                var toDoItemToUpdate = await _toDoItemRepository.GetById(id);

                if (toDoItemToUpdate == null)
                    return NotFound($"Task with Id = {id} not found");

                _toDoItemRepository.Update(toDoItem);
                return Ok(toDoItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var toDoItem = await _toDoItemRepository.GetById(id);

            if (toDoItem == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _toDoItemRepository.Delete(toDoItem);
            return Ok("Successful");
        }

    }
}

