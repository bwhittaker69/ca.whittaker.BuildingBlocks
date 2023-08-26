namespace ca.whittaker.blocks.Services;

using AutoMapper;
//using BCrypt.Net;
using ca.whittaker.blocks.Helpers;
using ca.whittaker.blocks.Models.Blocks;
using ca.whittaker.blocks.Entities;
using ca.whittaker.blocks.Repositories;

public interface IBlockService
{
    Task<IEnumerable<Block>> GetAll();
    Task<Block> GetById(int id);
    Task Create(CreateRequest model);
    Task Update(int id, UpdateRequest model);
    Task Delete(int id);
}

public class BlockService : IBlockService
{
    private IBlockRepository _blockRepository;
    private readonly IMapper _mapper;

    public BlockService(
        IBlockRepository blockRepository,
        IMapper mapper)
    {
        _blockRepository = blockRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Block>> GetAll()
    {
        return await _blockRepository.GetAll();
    }

    public async Task<Block> GetById(int id)
    {
        var user = await _blockRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        return user;
    }

    public async Task Create(CreateRequest model)
    {
        // validate
        //if (await _blockRepository.GetByEmail(model.Email!) != null)
            //throw new AppException("User with the email '" + model.Email + "' already exists");

        // map model to new user object
        var user = _mapper.Map<Block>(model);

        // hash password
        //user.PasswordHash = BCrypt.HashPassword(model.Password);

        // save user
        await _blockRepository.Create(user);
    }

    public async Task Update(int id, UpdateRequest model)
    {
        var user = await _blockRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        // validate
        //var emailChanged = !string.IsNullOrEmpty(model.Email) && user.Email != model.Email;
        //if (emailChanged && await _blockRepository.GetByEmail(model.Email!) != null)
            //throw new AppException("User with the email '" + model.Email + "' already exists");

        // hash password if it was entered
        //if (!string.IsNullOrEmpty(model.Password))
            //user.PasswordHash = BCrypt.HashPassword(model.Password);

        // copy model props to user
        _mapper.Map(model, user);

        // save user
        await _blockRepository.Update(user);
    }

    public async Task Delete(int id)
    {
        await _blockRepository.Delete(id);
    }
}