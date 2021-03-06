﻿using luigiDev.Market.Entities;
using luiguiDev.Market.Business.ProductBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace luigiDev.Market.Api.Controllers
{
    /// <summary>
    /// This api allows to process transactions related to products
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductBusiness productBusiness;
        public ProductController(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
        }

        /// <summary>
        /// Creates the specified product of a store.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                (bool created, string errorMessage) = await productBusiness.CreateProductAsync(product);

                if (!created)
                    return StatusCode((int)HttpStatusCode.BadRequest, errorMessage);

                // Ok() == 200 it means that the product was created successfully
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the specified product identifier of a store by Id.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            try
            {
                (bool deleted, string errorMessage) = await productBusiness.DeleteProductAsync(productId);

                if (!deleted)
                    return StatusCode((int)HttpStatusCode.BadRequest,errorMessage);

                // Ok() == 200 it means that the product was deleted successfully
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                (bool updated, string errorMessage) = await productBusiness.UpdateProductAsync(product);

                if (!updated)
                    return StatusCode((int)HttpStatusCode.BadRequest,errorMessage);

                // Ok() == 200 it means that the product was updated successfully
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            try
            {
                return Ok(await productBusiness.GetProductoByIdAsync(productId));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the products store.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Store/{storeId}")]
        public async Task<IActionResult> GetProductsStore(Guid storeId)
        {
            try
            {
                return Ok(await productBusiness.GetProductStoreAsync(storeId));
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await productBusiness.GetProductsAsync());
            }
            catch (Exception)
            {
                return StatusCode(statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
