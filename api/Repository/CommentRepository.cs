using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Data;
using dotnet_first.Dtos.Comment;
using dotnet_first.Interfaces;
using dotnet_first.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Repository
{
    public class CommentRepository(ApplicationDBContext context) : ICommentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            // var comments = _context.Comments.Include(a => a.AppUser).AsQueryable();

            // if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
            // {
            //     comments = comments.Where(s => s.Stock.Symbol == queryObject.Symbol);
            // };
            // if (queryObject.IsDecsending == true)
            // {
            //     comments = comments.OrderByDescending(c => c.CreatedOn);
            // }
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return existingComment;
        }

        public Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
        {
            throw new NotImplementedException();
        }
    }
}